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
                var response = await subscriberClient.PullAsync(subscriptionName, 10, stoppingToken);

                foreach (var receivedMessage in response.ReceivedMessages) {
                    var messageData = receivedMessage.Message.Data.ToStringUtf8();
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
                            if (httpresponse.StatusCode == System.Net.HttpStatusCode.OK) {
                                // Reconoce el mensaje
                                await subscriberClient.AcknowledgeAsync(subscriptionName, new[] { receivedMessage.AckId });
                            }
                            else {
                                var content = await httpresponse.Content.ReadAsStringAsync();
                                var errorCode = (int)httpresponse.StatusCode;
                                if (!string.IsNullOrWhiteSpace(content)) {
                                    try {
                                        var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(content, options);
                                        if (problemDetails != null) {
                                            logger.LogError("Api synchronizer error. Status: {Status} - Type: {Type} - Title: {Title} - Detail: {Detail} - Instance: {Instance}",
                                            problemDetails.Status,
                                            problemDetails.Type,
                                            problemDetails.Title,
                                            problemDetails.Detail,
                                            problemDetails.Instance);
                                        }
                                    }
                                    catch (Exception) {
                                        logger.LogError("Api synchronizer error. Status: {Status} ", errorCode);
                                    }
                                }
                                else {
                                    logger.LogError("Api synchronizer error. Status: {Status} ", errorCode);
                                }

                                //TODO: Pendiente de ver si se debe reintentar o no.
                                //404: Not Found, 500: Internal Server Error, 422: Unprocessable Entity, 400: Bad Request
                                if (errorCode == 404 || errorCode == 500) {

                                }
                            }
                        }
                    }
                    catch (JsonException ex) {
                        logger.LogError(ex, "An exception occurred while deserializing the message: {Message}", ex.Message);
                    }
                    //catch (HttpRequestException ex) {
                    //    // TODO: ver que hacer cuando la api no este disponible 
                    //}
                    catch (Exception ex) {
                        logger.LogError(ex, "An exception occurred while processing the message: {Message}", ex.Message);
                    }
                }
            }
            catch (Exception ex) {
                logger.LogError(ex, "An exception occurred while pulling messages: {Message}", ex.Message);
            }

            // Espera un breve período antes de la siguiente extracción
            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
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