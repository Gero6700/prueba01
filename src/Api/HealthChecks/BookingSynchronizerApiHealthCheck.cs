namespace Senator.As400.Cloud.Sync.Api.HealthChecks; 

public class BookingSynchronizerApiHealthCheck  : IHealthCheck {
    private readonly IConfiguration configuration;
    
    public BookingSynchronizerApiHealthCheck(IConfiguration configuration) {
        this.configuration = configuration;
    }
    
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken()) {
        var isBookingSynchronizarApiHealthy = CheckBookingSynchronizarApi();

        return Task.FromResult(isBookingSynchronizarApiHealthy 
            ? HealthCheckResult.Healthy("booking synchronizer api is running") 
            : HealthCheckResult.Unhealthy("booking synchronizer api is down"));
    }

    private bool CheckBookingSynchronizarApi() {
        var bookingSynchronizerApiSettings =
            configuration.GetSection("BookingSynchronizerApi").Get<BookingSynchronizerApiSettings>();

        CheckIfBookingSettingsExist(bookingSynchronizerApiSettings);

        var bookingSynchronizerApiHealthCheckUrl =
            $"{bookingSynchronizerApiSettings!.BaseUrl}{bookingSynchronizerApiSettings.HealthCheckEndpoint}";

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("x-api-version", "1.0");

        try {
            var bookingSynchronizerApiResponse = httpClient.GetAsync(bookingSynchronizerApiHealthCheckUrl).Result;
            return bookingSynchronizerApiResponse.IsSuccessStatusCode;
        }
        catch {
            return false;
        }
    }

    private static void CheckIfBookingSettingsExist(BookingSynchronizerApiSettings? bookingSynchronizerApiSettings) {
        if (bookingSynchronizerApiSettings is null || string.IsNullOrEmpty(bookingSynchronizerApiSettings.BaseUrl) ||
            string.IsNullOrEmpty(bookingSynchronizerApiSettings.HealthCheckEndpoint)) {
            throw new SettingsNotFoundException("Booking Synchronizer API settings do not exist");
        }
    }
}