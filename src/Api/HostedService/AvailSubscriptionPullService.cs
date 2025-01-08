namespace Senator.As400.Cloud.Sync.Api.HostedService;
public class AvailSubscriptionPullService(
        IConfiguration configuration, 
        ILogger<AvailSubscriptionPullService> logger,
        IEventHandler<GenericNotificationEvent> eventHandler
    ) : IHostedService {
    private Timer topicAvailPullTimer =  null!;
    private SubscriberClient subscriberClient = null!;
    private readonly JsonSerializerOptions serializeOptions = new () { PropertyNameCaseInsensitive = true };
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

    public Task StartAsync(CancellationToken cancellationToken) {
        CreateAvailSubscriptionPullTimer();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) {
        topicAvailPullTimer.Change(Timeout.Infinite, 0);
        topicAvailPullTimer.Dispose();
        return Task.CompletedTask;
    }

    private void CreateAvailSubscriptionPullTimer() {
        var pullInterval = configuration.GetSection("AvailGooglePubSub").Get<PubSubSettings>()!.IntervalInMinutes;
        topicAvailPullTimer = new Timer(HandleAvailSubscriptionPull, null, TimeSpan.Zero, TimeSpan.FromMinutes(pullInterval));
    }

    private async void HandleAvailSubscriptionPull(object? state) {
        var projectId = configuration["AvailGooglePubSub:ProjectId"];
        var subscriptionId = configuration["AvailGooglePubSub:SubscriptionId"];
        var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        subscriberClient ??= await SubscriberClient.CreateAsync(subscriptionName);

        await subscriberClient.StartAsync(async (PubsubMessage message, CancellationToken cancel) =>
        {
            //Se recupera y deserializa el mensaje
            var messageData = message.Data.ToStringUtf8();
            return await Task.FromResult(SubscriberClient.Reply.Nack);
            //try {
            //    var notification = JsonSerializer.Deserialize<As400Notification>(messageData, options);
            //    if (notification != null) {
            //        var genericNotificationEvent = new GenericNotificationEvent {
            //            Operation = notification.Operation,
            //            Table = notification.Table,
            //            Data = notification.Data,
            //            Entity = DeserializeEntity(notification)
            //        };
            //        var httpresponse = await eventHandler.HandleAsync(genericNotificationEvent);
            //        if (httpresponse.StatusCode == System.Net.HttpStatusCode.OK) {
            //            return await Task.FromResult(SubscriberClient.Reply.Ack);
            //        }
            //        else {
            //            var problemDetails = await httpresponse.Content.ReadFromJsonAsync<ProblemDetails>();
            //            if (problemDetails != null) {
            //                logger.LogError("Api synchronizer error. Status: {Status} - Type: {Type} - Title: {Title} - Detail: {Detail} - Instance: {Instance}",
            //                problemDetails.Status,
            //                problemDetails.Type,
            //                problemDetails.Title,
            //                problemDetails.Detail,
            //                problemDetails.Instance);

            //                switch (problemDetails.Status) {
            //                    case 404: // Not Found. Se para la subscripcion
            //                              //TODO
            //                        break;
            //                    case 500: // Internal Server Error. No se marca para reintentar

            //                    case 422: // Unprocessable Entity. Se marca con error
            //                              //return await Task.FromResult(SubscriberClient.Reply.Nack);
            //                    case 400: // Bad Request. Se marca con error
            //                              //return await Task.FromResult(SubscriberClient.Reply.Nack);
            //                    default:
            //                        return await Task.FromResult(SubscriberClient.Reply.Nack);
            //                }
            //            }
            //        }
            //    }
            //}
            ////catch (JsonException ex) {
            ////    logger.LogError(ex, "An exception occurred while deserializing the message: {Message}", ex.Message);
            ////    return await Task.FromResult(SubscriberClient.Reply.Nack);
            ////}
            //catch (HttpRequestException ex) {
            //    //TODO: ver que hacer cuando la api no este disponible 
            //    return await Task.FromResult(SubscriberClient.Reply.Nack);
            //}
            ////catch (Exception ex) {
            ////    logger.LogError(ex, "An exception occurred while processing the message: {Message}", ex.Message);
            ////}
            ////// Acknowledge the message
            //return await Task.FromResult(SubscriberClient.Reply.Nack);
        });
    }

    private object DeserializeEntity(As400Notification notification) {             
        if (typeMap.TryGetValue(notification.Table, out var type)) {
            var entity = JsonSerializer.Deserialize(notification.Data, type, serializeOptions);
            return entity ?? throw new InvalidOperationException($"Deserialization returned null for table type: {notification.Table}");
        }

        throw new InvalidOperationException($"Unsupported table type: {notification.Table}");
    }

    private class As400Notification : NotificationEvent { }
}
