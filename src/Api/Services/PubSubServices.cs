namespace Senator.As400.Cloud.Sync.Api.Services;
public static class PubSubServices {
    public static IServiceCollection AddPubSubServices(this IServiceCollection services, IConfiguration configuration) {
        //subscription to quota
        var projectId = configuration["QuotaGooglePubSub:ProjectId"];
        var subscriptionId = configuration["QuotaGooglePubSub:SubscriptionId"];
        var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);

        services.AddSubscriberClient(subscriptionName);
        services.AddHostedService<SubscriptionPullStreamingService>();

        //subscription to avail and static 
        services.AddSubscriberServiceApiClient();
        services.AddHostedService<AvailSubscriptionPullService>();
        services.AddHostedService<StaticSubscriptionPullService>();

        return services;
    }
}
