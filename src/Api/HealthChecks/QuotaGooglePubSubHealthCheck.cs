
namespace Senator.As400.Cloud.Sync.Api.HealthChecks;
public class QuotaGooglePubSubHealthCheck : IHealthCheck {
    private readonly IConfiguration configuration;

    public QuotaGooglePubSubHealthCheck(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken()) {
        return Task.FromResult(CheckQuotaGooglePubSub()
            ? HealthCheckResult.Healthy("Google Pub/Sub Quota subscription is reachable")
            : HealthCheckResult.Unhealthy("Google Pub/Sub Quota subscription is not reachable"));
    }

    private bool CheckQuotaGooglePubSub() {
        var quotaPubSubSettings =
            configuration.GetSection("QuotaGooglePubSub").Get<PubSubSettings>();
        CheckIfQuotaGooglePubSubSettingsExist(quotaPubSubSettings);

        var projectId = quotaPubSubSettings!.ProjectId;
        var subscriptionId = quotaPubSubSettings.SubscriptionId;

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

    private static void CheckIfQuotaGooglePubSubSettingsExist(PubSubSettings? quotaGooglePubSubSettings) {
        if (quotaGooglePubSubSettings is null || string.IsNullOrEmpty(quotaGooglePubSubSettings.ProjectId) ||
            string.IsNullOrEmpty(quotaGooglePubSubSettings.SubscriptionId)) {
            throw new SettingsNotFoundException("Quota Google Pub/Sub settings do not exist");
        }
    }
}