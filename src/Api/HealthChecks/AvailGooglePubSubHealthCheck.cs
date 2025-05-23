namespace Senator.As400.Cloud.Sync.Api.HealthChecks;

public class AvailGooglePubSubHealthCheck : IHealthCheck {
    private readonly IConfiguration configuration;

    public AvailGooglePubSubHealthCheck(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,CancellationToken cancellationToken = new CancellationToken()) {
        
        return Task.FromResult(CheckAvailGooglePubSub()
            ? HealthCheckResult.Healthy("Google Pub/Sub Avail subscription is reachable")
            : HealthCheckResult.Unhealthy("Google Pub/Sub Avail subscription is not reachable"));
    }

    private bool CheckAvailGooglePubSub() {
        var availPubSubSettings =
            configuration.GetSection("AvailGooglePubSub").Get<PubSubSettings>();
        CheckIfAvailGooglePubSubSettingsExist(availPubSubSettings);

        var projectId = availPubSubSettings!.ProjectId;
        var subscriptionId = availPubSubSettings.SubscriptionId;

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

    private static void CheckIfAvailGooglePubSubSettingsExist(PubSubSettings? availGooglePubSubSettings) {
        if (availGooglePubSubSettings is null || string.IsNullOrEmpty(availGooglePubSubSettings.ProjectId) ||
            string.IsNullOrEmpty(availGooglePubSubSettings.SubscriptionId)) {
            throw new SettingsNotFoundException("Avail Google Pub/Sub settings do not exist");
        }
    }
}
