namespace Senator.As400.Cloud.Sync.Api.HostedService;
public class AvailSubscriptionPullService(
        IConfiguration configuration,
        SubscriberServiceApiClient subscriberClient,
        ILogger<AvailSubscriptionPullService> logger,
        ISynchronizerHandler<GenericSynchronizationEvent> synchronizationHandler
    ) : BackgroundService {
    private readonly JsonSerializerOptions serializeOptions = new() { PropertyNameCaseInsensitive = true };
    private readonly Dictionary<string, Type> typeMap = new() {
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
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var projectId = configuration["AvailGooglePubSub:ProjectId"];
        var subscriptionId = configuration["AvailGooglePubSub:SubscriptionId"];
        var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
        
        while (!stoppingToken.IsCancellationRequested) {
            try {
                // Realiza una operación de extracción (pull) asincrónica
                var response = await subscriberClient.PullAsync(subscriptionName, 50, stoppingToken);

                foreach (var receivedMessage in response.ReceivedMessages) {
                    var messageData = receivedMessage.Message.Data.ToStringUtf8();
                    //await subscriberClient.AcknowledgeAsync(subscriptionName, [receivedMessage.AckId]);
                    try {
                        var notification = JsonSerializer.Deserialize<As400Notification>(messageData, options);
                        if (notification != null) {
                            var genericSynchronizationEvent = new GenericSynchronizationEvent {
                                Operation = notification.Operation,
                                Table = notification.Table,
                                Data = notification.Data,
                                Entity = DeserializeEntity(notification)
                            };
                            var httpresponse = await synchronizationHandler.HandleAsync(genericSynchronizationEvent);

                            if (httpresponse.IsSuccessStatusCode) {
                                await subscriberClient.AcknowledgeAsync(subscriptionName, [receivedMessage.AckId]);
                            }
                            else {
                                var content = await httpresponse.Content.ReadAsStringAsync();
                                var errorCode = (int)httpresponse.StatusCode;
                                var logProblemDetails = "";
                                ProblemDetails? problemDetails = null;

                                try {
                                    problemDetails = !string.IsNullOrWhiteSpace(content) ? JsonSerializer.Deserialize<ProblemDetails>(content, options) : null;
                                } catch { }                             
                                                                
                                logProblemDetails = $"Api synchronizer error: Status: {problemDetails?.Status ?? errorCode} - " +
                                    $"Type: {problemDetails?.Type} - Title: {problemDetails?.Title} - Detail: {problemDetails?.Detail} - Instance: {problemDetails?.Instance}";                                        
                                

                                //TODO: Pendiente de ver si se debe reintentar o no.
                                //404: Not Found, 500: Internal Server Error, 422: Unprocessable Entity, 400: Bad Request
                                if (errorCode == 404 || errorCode == 500) {
                                    logger.LogError("Pulling process is aborted, it will starts in 5s. An error occurred while sending the message to Synchronizer Api. " +
                                        "AckId: {Ackid} - PublishTime: {Publishtime} - Data: {data} ",
                                        receivedMessage.AckId,
                                        receivedMessage.Message.PublishTime.ToDateTime(),
                                        messageData);
                                    break;
                                } else {
                                    logger.LogError(GenerateLogMessage("The message has been refused.", receivedMessage, messageData));
                                    await subscriberClient.AcknowledgeAsync(subscriptionName, [receivedMessage.AckId]);
                                }
                            }
                        }
                    } catch (JsonException ex) {
                        logger.LogError(GenerateLogMessage("The message has been refused. An exception occurred while deserializing the message.", receivedMessage, messageData));
                        await subscriberClient.AcknowledgeAsync(subscriptionName, [receivedMessage.AckId]);
                    } catch (HttpRequestException ex) {
                        logger.LogError(GenerateLogMessage("The message has been refused. An exception occurred while deserializing the message.", receivedMessage, messageData));
                        // Salir del bucle si se produce un error de red/comunicación. Así nos aseguramos el orden en el procesamiento de los mensajes.
                        logger.LogError(ex, "Pulling process is aborted, it will starts in 5s. An exception occurred while sending the message to Synchronizer Api. " +
                            "AckId: {Ackid} - PublishTime: {Publishtime} - Data: {data} -  Exception: {Message} ",
                            receivedMessage.AckId,
                            receivedMessage.Message.PublishTime.ToDateTime(),
                            messageData,
                            ex.Message);
                        break;
                    } catch (Exception ex) {
                        logger.LogError(GenerateLogMessage("The message has been refused. An exception occurred while processing the message.", receivedMessage, messageData));
                        await subscriberClient.AcknowledgeAsync(subscriptionName, [receivedMessage.AckId]);
                    }
                }
            } catch (Exception ex) {
                logger.LogError(ex, "An exception occurred while pulling messages: {Message}", ex.Message);
            }

            // Espera un breve período antes de la siguiente extracción
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }

    private string GenerateLogMessage(string message, ReceivedMessage receivedMessage, string messageData) {
        return $"{message} AckId: {receivedMessage.AckId} - PublishTime: {receivedMessage.Message.PublishTime.ToDateTime()} - Data: {messageData}";
    }

    private object DeserializeEntity(As400Notification notification) {
        if (typeMap.TryGetValue(notification.Table, out var type)) {
            var entity = JsonSerializer.Deserialize(notification.Data, type, serializeOptions);
            return entity ?? throw new InvalidOperationException($"Deserialization returned null for table type: {notification.Table}");
        }

        throw new InvalidOperationException($"Unsupported table type: {notification.Table}");
    }

    private class As400Notification : SynchronizationEvent { }
}