namespace Senator.As400.Cloud.Sync.Api.HostedService;

//Servicio de extraccion de mensajes mediante API de pull streaming de Google Pub/Sub.
//Para mas detalles de la API de Google Pub/Sub: https://cloud.google.com/pubsub/docs/pull?hl=es-419#high_client_library
public class PubSubPullStreamingService(
        SubscriberClient subscriberClient,
        ILogger<PubSubPullStreamingService> logger,
        ISynchronizerHandler<GenericSynchronizationEvent> synchronizerHandler
    ) : BackgroundService {
    private readonly JsonSerializerOptions serializeOptions = new() { PropertyNameCaseInsensitive = true };
    private readonly Dictionary<string, Type>  typeMap = new () {
        {nameof(TableType.CancellationPolicyLine), typeof(Congasan)},
        {nameof(TableType.Client), typeof(Usureg)},
        {nameof(TableType.ClientType), typeof(Restagen)},
        {nameof(TableType.Contract), typeof(Concabec)},
        {nameof(TableType.Extra), typeof(Conextra)},
        {nameof(TableType.Hotel), typeof(Reshotel)},
        {nameof(TableType.HotelRoomConfiguration), typeof(Resthaho)},
        {nameof(TableType.Inventory), typeof(Resplaht)},
        {nameof(TableType.Market), typeof(Merca)},
        {nameof(TableType.MinimumStay), typeof(Conestmi)},
        {nameof(TableType.OccupancyRate), typeof(Resthaco)},
        {nameof(TableType.OfferAndSupplement), typeof(Conofege)},
        {nameof(TableType.OfferAndSupplementConfigurationPax), typeof(Condtof)},
        {nameof(TableType.OfferAndSupplementGroup), typeof(ConofcomHeader)},
        {nameof(TableType.OfferAndSupplementGroupOfferAndSupplement), typeof(ConofcomLine)},
        {nameof(TableType.PeriodPricing), typeof(Conpreci)},
        {nameof(TableType.PeriodPricingPax), typeof(Condtos)},
        {nameof(TableType.Regimen), typeof(Restregi)}
    };


    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        await subscriberClient.StartAsync(async (PubsubMessage message, CancellationToken messageToken) => {
            if (stoppingToken.IsCancellationRequested) {
                return SubscriberClient.Reply.Nack;
            }

            return await ProcessMessageAsync(message);
        });
    }

    private async Task<SubscriberClient.Reply> ProcessMessageAsync(PubsubMessage message) {
        // Se recupera y deserializa el mensaje
        var messageData = string.Empty;
        try {
            messageData = message.Data.ToStringUtf8();
            var notification = JsonSerializer.Deserialize<As400Notification>(messageData, serializeOptions) ??
                throw new InvalidOperationException("The message could not be deserialized");
            var genericSynchronizationEvent = new GenericSynchronizationEvent {
                Operation = notification.Operation,
                Table = notification.Table,
                Data = notification.Data,
                Entity = DeserializeEntity(notification)
            };
            var httpResponse = await synchronizerHandler.HandleAsync(genericSynchronizationEvent);
            if (!httpResponse.IsSuccessStatusCode) {
                var content = await httpResponse.Content.ReadAsStringAsync();
                var errorCode = (int)httpResponse.StatusCode;
                ProblemDetails? problemDetails = null;

                try {
                    problemDetails = !string.IsNullOrWhiteSpace(content) ? JsonSerializer.Deserialize<ProblemDetails>(content, serializeOptions) : null;
                }
                catch { }

                if (errorCode == 404 || errorCode == 500) {
                    //Se reintenta el mensaje
                    logger.LogError("An error occurred while sending the message to Synchronizer Api. It will retry automatically again. {Message}",
                        GenerateLogApi(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, errorCode, problemDetails));
                    return SubscriberClient.Reply.Nack;
                }
                else {
                    logger.LogError("The message has been refused. An error occurred while sending the message to Synchronizer Api. {Message}",
                        GenerateLogApi(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId,message, messageData, errorCode, problemDetails));
                    return SubscriberClient.Reply.Ack;
                }
            }
            else {
                return SubscriberClient.Reply.Ack;
            }
        }
        catch (JsonException ex) {
            logger.LogError("The message has been refused. An exception occurred while deserializing the message: {Message}",
                GenerateLogMessage(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, ex.Message));
            return SubscriberClient.Reply.Ack;
        }
        catch (HttpRequestException ex) {
            logger.LogError("An exception occurred while sending the message to Synchronizer Api. It will retry automatically again: {Message}",
                GenerateLogMessage(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, ex.Message));
            return SubscriberClient.Reply.Nack;
        }
        catch (Exception ex) {
            logger.LogError("The message has been refused. An exception occurred while processing the message: {Message}",
                GenerateLogMessage(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, ex.Message));
            return SubscriberClient.Reply.Ack;
        }
    }

    private static string GenerateLogMessage(string projectId, string subscriptionId, PubsubMessage receivedMessage, string messageData, string errorMessage) {
        return $"{errorMessage}{Environment.NewLine}Project:{projectId}{Environment.NewLine}Subscription: {subscriptionId}{Environment.NewLine}" +
            $"MessageId: {receivedMessage.MessageId}{Environment.NewLine}PublishTime: {receivedMessage.PublishTime.ToDateTime()}{Environment.NewLine}Data: {messageData}";
    }

    private static string GenerateLogApi(string projectId, string subscriptionId, PubsubMessage received, string messageData, int errorCode, ProblemDetails? problemDetails) {
        return GenerateLogMessage(projectId, subscriptionId, received, messageData,
            $"Api synchronizer error: {problemDetails?.Status ?? errorCode}{Environment.NewLine}Type: {problemDetails?.Type}{Environment.NewLine}" +
            $"Title: {problemDetails?.Title}{Environment.NewLine}Detail: {problemDetails?.Detail}{Environment.NewLine}Instance: {problemDetails?.Instance}");
    }


    public override async Task StopAsync(CancellationToken stoppingToken) =>
        await subscriberClient.StopAsync(stoppingToken);

    private object DeserializeEntity(As400Notification notification) {             
        if (typeMap.TryGetValue(notification.Table, out var type)) {
            var entity = JsonSerializer.Deserialize(notification.Data, type, serializeOptions);
            return entity ?? throw new InvalidOperationException($"Deserialization returned null for table type: {notification.Table}");
        }

        throw new InvalidOperationException($"Unsupported table type: {notification.Table}");
    }   

    private class As400Notification : SynchronizationEvent { }
}
