
namespace Senator.As400.Cloud.Sync.Api.HostedService;

public class AvailSubscriptionPullService(
        IConfiguration configuration,
        SubscriberServiceApiClient subscriberClient,
        ILogger<AvailSubscriptionPullService> logger,
        ISynchronizerHandler<GenericSynchronizationEvent> synchronizationHandler,
        IAs400NotificationApiClient as400NotificationApiClient
    ) : SubscriptionPullService (subscriberClient, logger, synchronizationHandler, as400NotificationApiClient) {

    protected override string GetProjectId() => configuration["AvailGooglePubSub:ProjectId"]!;
    protected override string GetSubscriptionId() => configuration["AvailGooglePubSub:SubscriptionId"]!;
    protected override int GetPullMaxMessages() => int.Parse(configuration["AvailGooglePubSub:PullMaxMessages"] ?? "0");

    protected override Dictionary<string, Type> typeMap => new() {
        {nameof(TableType.CancellationPolicyLine), typeof(Congasan)},
        {nameof(TableType.Client), typeof(Usureg)},
        {nameof(TableType.ClientType), typeof(Restagen)},
        {nameof(TableType.Contract), typeof(Concabec)},
        {nameof(TableType.Extra), typeof(Conextra)},
        {nameof(TableType.Hotel), typeof(Reshotel)},
        {nameof(TableType.HotelRoomConfiguration), typeof(Resthaho)},
        {nameof(TableType.HotelSeason), typeof(Hotape)},
        {nameof(TableType.Market), typeof(Merca)},
        {nameof(TableType.MinimumStay), typeof(Conestmi)},
        {nameof(TableType.OccupancyRate), typeof(Resthaco)},
        {nameof(TableType.OfferAndSupplement), typeof(Conofege)},
        {nameof(TableType.OfferAndSupplementConfigurationPax), typeof(Condtof)},
        {nameof(TableType.OfferAndSupplementGroup), typeof(ConofcomHeader)},
        {nameof(TableType.OfferAndSupplementGroupOfferAndSupplement), typeof(ConofcomLine)},
        {nameof(TableType.PeriodPricing), typeof(Conpreci)},
        {nameof(TableType.PeriodPricingPax), typeof(Condtos)},
        {nameof(TableType.Regime), typeof(Restregi)},
        {nameof(TableType.Room), typeof(Resthabi)},
    };
}