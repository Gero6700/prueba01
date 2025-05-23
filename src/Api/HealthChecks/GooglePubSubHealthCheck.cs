namespace Senator.As400.Cloud.Sync.Api.HealthChecks; 

public class GooglePubSubHealthCheck : IHealthCheck {
    private readonly IConfiguration configuration;
    
    public GooglePubSubHealthCheck(IConfiguration configuration) {
        this.configuration = configuration;
    }
    
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken()) {
        var isStaticDataSynchronizarApiHealthy = CheckStaticDataSynchronizarApi();

        return Task.FromResult(isStaticDataSynchronizarApiHealthy 
            ? HealthCheckResult.Healthy("static data synchronizer api is running") 
            : HealthCheckResult.Unhealthy("static data synchronizer api is down"));
    }

    private bool CheckStaticDataSynchronizarApi() {
        var staticDataSynchronizerApiSettings =
            configuration.GetSection("StaticDataSynchronizerApi").Get<StaticDataSynchronizerApiSettings>();

        CheckIfStaticDataSettingsExist(staticDataSynchronizerApiSettings);

        var staticDataSynchronizerApiHealthCheckUrl =
            $"{staticDataSynchronizerApiSettings!.BaseUrl}{staticDataSynchronizerApiSettings.HealthCheckEndpoint}";

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-version", "1.0");

        try {
            var staticDataSynchronizerApiResponse = httpClient.GetAsync(staticDataSynchronizerApiHealthCheckUrl).Result;
            return staticDataSynchronizerApiResponse.IsSuccessStatusCode;
        }
        catch {
            return false;
        }
    }

    private static void CheckIfStaticDataSettingsExist(StaticDataSynchronizerApiSettings? staticDataSynchronizerApiSettings) {
        if (staticDataSynchronizerApiSettings is null || string.IsNullOrEmpty(staticDataSynchronizerApiSettings.BaseUrl) ||
            string.IsNullOrEmpty(staticDataSynchronizerApiSettings.HealthCheckEndpoint)) {
            throw new SettingsNotFoundException("Static Data Synchronizer API settings do not exist");
        }
    }
}