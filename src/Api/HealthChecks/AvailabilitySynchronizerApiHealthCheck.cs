namespace Senator.As400.Cloud.Sync.Api.HealthChecks; 

public class AvailabilitySynchronizerApiHealthCheck : IHealthCheck {
    private readonly IConfiguration configuration;
    
    public AvailabilitySynchronizerApiHealthCheck(IConfiguration configuration) {
        this.configuration = configuration;
    }
    
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken()) {
        var isAvailabilitySynchronizerApiHealthy = CheckAvailabilitySynchronizerApi();

        return Task.FromResult(isAvailabilitySynchronizerApiHealthy 
            ? HealthCheckResult.Healthy("availability synchronizer api is running") 
            : HealthCheckResult.Unhealthy("availability synchronizer api is down"));
    }

    private bool CheckAvailabilitySynchronizerApi() {
        var availabilitySynchronizerApiSettings =
            configuration.GetSection("AvailabilitySynchronizerApi").Get<AvailabilitySynchronizerApiSettings>();

        CheckIfAvailabilitySettingsExist(availabilitySynchronizerApiSettings);

        var availabilitySynchronizerApiHealthCheckUrl =
            $"{availabilitySynchronizerApiSettings!.BaseUrl}{availabilitySynchronizerApiSettings.HealthCheckEndpoint}";

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-version", "1.0");

        try {
            var availabilitySynchronizerApiResponse = httpClient.GetAsync(availabilitySynchronizerApiHealthCheckUrl).Result;
            return availabilitySynchronizerApiResponse.IsSuccessStatusCode;
        }
        catch {
            return false;
        }
    }

    private static void CheckIfAvailabilitySettingsExist(AvailabilitySynchronizerApiSettings? availabilitySynchronizerApiSettings) {
        if (availabilitySynchronizerApiSettings is null || string.IsNullOrEmpty(availabilitySynchronizerApiSettings.BaseUrl) ||
            string.IsNullOrEmpty(availabilitySynchronizerApiSettings.HealthCheckEndpoint)) {
            throw new SettingsNotFoundException("Availability Synchronizer API settings do not exist");
        }
    }
}