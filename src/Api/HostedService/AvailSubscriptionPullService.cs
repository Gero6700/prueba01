
namespace Senator.As400.Cloud.Sync.Api.HostedService;

public class AvailSubscriptionPullService(
        IConfiguration configuration,
        SubscriberServiceApiClient subscriberClient,
        ILogger<AvailSubscriptionPullService> logger,
        ISynchronizerHandler<GenericSynchronizationEvent> synchronizationHandler
    ) : BaseSubscriptionPullService (subscriberClient, logger, synchronizationHandler) {

    protected override string GetProjectId() => configuration["AvailGooglePubSub:ProjectId"]!;
    protected override string GetSubscriptionId() => configuration["AvailGooglePubSub:SubscriptionId"]!;
    protected override int GetPullIntervalInSeconds() => int.Parse(configuration["AvailGooglePubSub:PullIntervalInSeconds"] ?? "0");

    protected override Dictionary<string, Type> typeMap => new() {
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
    //protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
    //    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    //    var availPubSubSettings = configuration.GetSection("AvailGooglePubSub").Get<PubSubSettings>();
    //    var projectId = availPubSubSettings!.ProjectId;
    //    var subscriptionId = availPubSubSettings!.SubscriptionId;
    //    var intervalInSeconds = availPubSubSettings!.PullIntervalInSeconds;
    //    var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);

    //    while (!stoppingToken.IsCancellationRequested) {
    //        try {
    //            // Realiza una operación de extracción (pull) asincrónica
    //            var response = await subscriberClient.PullAsync(subscriptionName, 20, stoppingToken);

    //            foreach (var receivedMessage in response.ReceivedMessages) {
    //                var messageData = string.Empty;
    //                //Console.WriteLine($"{receivedMessage.Message.PublishTime}, AckId: {receivedMessage.AckId}");
    //                //await subscriberClient.AcknowledgeAsync(subscriptionName, [receivedMessage.AckId]);
    //                try {
    //                    messageData = receivedMessage.Message.Data.ToStringUtf8();
    //                    var notification = JsonSerializer.Deserialize<As400Notification>(messageData, options) ?? throw new InvalidOperationException("The message could not be deserialized");
    //                    var genericSynchronizationEvent = new GenericSynchronizationEvent {
    //                        Operation = notification.Operation,
    //                        Table = notification.Table,
    //                        Data = notification.Data,
    //                        Entity = DeserializeEntity(notification)
    //                    };
    //                    var httpresponse = await synchronizationHandler.HandleAsync(genericSynchronizationEvent);

    //                    if (!httpresponse.IsSuccessStatusCode) {
    //                        var content = await httpresponse.Content.ReadAsStringAsync();
    //                        var errorCode = (int)httpresponse.StatusCode;
    //                        ProblemDetails? problemDetails = null;

    //                        try {
    //                            problemDetails = !string.IsNullOrWhiteSpace(content) ? JsonSerializer.Deserialize<ProblemDetails>(content, options) : null;
    //                        }
    //                        catch { }

    //                        //404: Not Found, 500: Internal Server Error, 422: Unprocessable Entity, 400: Bad Request
    //                        if (errorCode == 404 || errorCode == 500) {
    //                            //Se sale del bucle si se produce un error de comunicación. Así nos aseguramos el orden en el procesamiento de los mensajes.
    //                            logger.LogError("Pulling process is aborted, it will restart automatically. An error occurred while sending the message to Synchronizer Api: {message}",
    //                                GenerateLogApi(projectId, subscriptionId, receivedMessage.Message, messageData, errorCode, problemDetails));
    //                            break;
    //                        }
    //                        else {
    //                            logger.LogError("The message has been refused. An error occurred while sending the message to Synchronizer Api: {message}",
    //                                GenerateLogApi(projectId, subscriptionId, receivedMessage.Message, messageData, errorCode, problemDetails));
    //                        }
    //                    }
    //                }
    //                catch (JsonException ex) {
    //                    logger.LogError("The message has been refused. An exception occurred while deserializing the message: {message}",
    //                        GenerateLogMessage(projectId, subscriptionId, receivedMessage.Message, messageData, ex.Message));
    //                }
    //                catch (HttpRequestException ex) {
    //                    // Salir del bucle si se produce un error de red/comunicación. Así nos aseguramos el orden en el procesamiento de los mensajes.
    //                    logger.LogError("Pulling process is aborted, it will restart automatically. An exception occurred while sending the message to Synchronizer Api: {message}",
    //                        GenerateLogMessage(projectId, subscriptionId, receivedMessage.Message, messageData, ex.Message));
    //                    break;
    //                }
    //                catch (Exception ex) {
    //                    logger.LogError("The message has been refused. An exception occurred while processing the message {message}",
    //                        GenerateLogMessage(projectId, subscriptionId, receivedMessage.Message, messageData, ex.Message));
    //                }

    //                await subscriberClient.AcknowledgeAsync(subscriptionName, [receivedMessage.AckId]);
    //            }
    //        } catch (Exception ex) {
    //            logger.LogError(ex, "An exception occurred while pulling messages: {Message}", ex.Message);
    //        }

    //        // Espera un breve período antes de la siguiente extracción
    //        await Task.Delay(TimeSpan.FromSeconds(intervalInSeconds), stoppingToken);
    //    }
    //}

    //private static string GenerateLogMessage(string projectId, string subscriptionId, PubsubMessage receivedMessage, string messageData, string errorMessage) {
    //    return $"{errorMessage}{Environment.NewLine}Project:{projectId}{Environment.NewLine}Subscription: {subscriptionId}{Environment.NewLine}" +
    //        $"MessageId: {receivedMessage.MessageId}{Environment.NewLine}PublishTime: {receivedMessage.PublishTime.ToDateTime()}{Environment.NewLine}Data: {messageData}";
    //}

    //private static string GenerateLogApi(string projectId, string subscriptionId, PubsubMessage received, string messageData, int errorCode, ProblemDetails? problemDetails) {
    //    return GenerateLogMessage(projectId, subscriptionId, received, messageData, 
    //        $"Api synchronizer error: {problemDetails?.Status ?? errorCode}{Environment.NewLine}Type: {problemDetails?.Type}{Environment.NewLine}" +
    //        $"Title: {problemDetails?.Title}{Environment.NewLine}Detail: {problemDetails?.Detail}{Environment.NewLine}Instance: {problemDetails?.Instance}");
    //}

    //private object DeserializeEntity(As400Notification notification) {
    //    if (typeMap.TryGetValue(notification.Table, out var type)) {
    //        var entity = JsonSerializer.Deserialize(notification.Data, type, serializeOptions);
    //        return entity ?? throw new InvalidOperationException($"Deserialization returned null for table type: {notification.Table}");
    //    }

    //    throw new InvalidOperationException($"Unsupported table type: {notification.Table}");
    //}

    //private class As400Notification : SynchronizationEvent { }
}