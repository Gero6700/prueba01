namespace Senator.As400.Cloud.Sync.Api.HostedService;
public class StaticSubscriptionPullService(
    IConfiguration configuration,
        SubscriberServiceApiClient subscriberClient,
        ILogger<StaticSubscriptionPullService> logger,
        ISynchronizerHandler<GenericSynchronizationEvent> synchronizationHandler
    ) : SubscriptionPullService(subscriberClient, logger, synchronizationHandler, null) {

    protected override string GetProjectId() => configuration["StaticGooglePubSub:ProjectId"]!;
    protected override string GetSubscriptionId() => configuration["StaticGooglePubSub:SubscriptionId"]!;
    protected override int GetPullIntervalInSeconds() => int.Parse(configuration["StaticGooglePubSub:PullIntervalInSeconds"] ?? "0");

    protected override Dictionary<string, Type> typeMap => new() {
        {nameof(TableType.ExtraTranslation), typeof(Desextr)},
        {nameof(TableType.OfferAndSupplementTranslation), typeof(Desofer)},
        {nameof(TableType.PaymentType), typeof(Forpago)},
        {nameof(TableType.Tax), typeof(Reszoim)}  ,
        {nameof(TableType.HotelTax), typeof(Reszoimh)},
    };
}
