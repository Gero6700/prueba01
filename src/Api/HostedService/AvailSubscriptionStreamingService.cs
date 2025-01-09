namespace Senator.As400.Cloud.Sync.Api.HostedService;
public class AvailSubscriptionStreamingService(
        SubscriberClient subscriberClient,
        ILogger<AvailSubscriptionStreamingService> logger,
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
        await subscriberClient.StartAsync(async (PubsubMessage message, CancellationToken stoppingToken) => {
            if (stoppingToken.IsCancellationRequested) {
                return await Task.FromResult(SubscriberClient.Reply.Nack);
            }
            //Se recupera y deserializa el mensaje
            var messageData = message.Data.ToStringUtf8();
            try {
                var notification = JsonSerializer.Deserialize<As400Notification>(messageData, serializeOptions);
                if (notification != null) {
                    var genericSynchronizationEvent = new GenericSynchronizationEvent {
                        Operation = notification.Operation,
                        Table = notification.Table,
                        Data = notification.Data,
                        Entity = DeserializeEntity(notification)
                    };
                    var httpresponse = await synchronizerHandler.HandleAsync(genericSynchronizationEvent);
                    if (!httpresponse.IsSuccessStatusCode) {
                        var content = await httpresponse.Content.ReadAsStringAsync();
                        var errorCode = (int)httpresponse.StatusCode;
                        if (!string.IsNullOrWhiteSpace(content)) {
                            try {
                                var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(content, serializeOptions);
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
                        } else {
                            logger.LogError("Api synchronizer error. Status: {Status} ", errorCode);
                        }

                        //TODO: Pendiente de ver si se debe reintentar o no. Tener en cuenta que en streaming los reintentos pueden conllevar a un procesamiento desordenado ya que
                        //mientras se reintentan los mensajes, los nuevos siguen llegando.
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
            //    //TODO: ver que hacer cuando la api no este disponible 
            //    return await Task.FromResult(SubscriberClient.Reply.Nack);
            //}
            catch (Exception ex) {
                logger.LogError(ex, "An exception occurred while processing the message: {Message}", ex.Message);
            }
            //No contemplo el caso de error en el procesamiento del mensaje, porque podria producir que se procesara desordenado. 
            //En su lugar habria que contemplar un mecanismo de reintentos.
            return await Task.FromResult(SubscriberClient.Reply.Ack);
        });
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
