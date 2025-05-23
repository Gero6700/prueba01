namespace Senator.As400.Cloud.Sync.Api.HealthChecks;
public class StaticGooglePubSubHealthCheck : IHealthCheck {
    private readonly IConfiguration configuration;

    public StaticGooglePubSubHealthCheck(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken()) {
        return Task.FromResult(CheckStaticGooglePubSub()
            ? HealthCheckResult.Healthy("Google Pub/Sub Static subscription is reachable")
            : HealthCheckResult.Unhealthy("Google Pub/Sub Static subscription is not reachable"));
    }

    private bool CheckStaticGooglePubSub() {
        var staticPubSubSettings =
            configuration.GetSection("StaticGooglePubSub").Get<PubSubSettings>();
        CheckIfStaticGooglePubSubSettingsExist(staticPubSubSettings);

        var projectId = staticPubSubSettings!.ProjectId;
        var subscriptionId = staticPubSubSettings.SubscriptionId;

        try {
            var subscriber = SubscriberServiceApiClient.Create();
            var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);

            // Intenta obtener la configuración de la suscripción
            var subscription = subscriber.GetSubscription(subscriptionName);

            return true;
        }
        catch (Exception) {
            return false;
        }
    }

    private static void CheckIfStaticGooglePubSubSettingsExist(PubSubSettings? staticGooglePubSubSettings) {
        if (staticGooglePubSubSettings is null || string.IsNullOrEmpty(staticGooglePubSubSettings.ProjectId) ||
            string.IsNullOrEmpty(staticGooglePubSubSettings.SubscriptionId)) {
            throw new SettingsNotFoundException("Static Google Pub/Sub settings do not exist");
        }
    }
}
