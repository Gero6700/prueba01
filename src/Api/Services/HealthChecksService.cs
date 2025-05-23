namespace Senator.As400.Cloud.Sync.Api.Services; 

public static class HealthChecksService {
    public static IServiceCollection AddHealthChecksService(this IServiceCollection services) {
        var healthChecksBuilder = services.AddHealthChecks();
        AddAvailGooglePubSubHealthCheck(healthChecksBuilder);
        AddQuotaGooglePubSubHealthCheck(healthChecksBuilder);
        AddStaticGooglePubSubHealthCheck(healthChecksBuilder);
        return services;
    }

    private static void AddAvailGooglePubSubHealthCheck(IHealthChecksBuilder healthChecksBuilder) {
        healthChecksBuilder.AddCheck<AvailGooglePubSubHealthCheck>("connection to avail google pub sub");
    }

    private static void AddQuotaGooglePubSubHealthCheck(IHealthChecksBuilder healthChecksBuilder) {
        healthChecksBuilder.AddCheck<QuotaGooglePubSubHealthCheck>("connection to quota google pub sub");
    }

    private static void AddStaticGooglePubSubHealthCheck(IHealthChecksBuilder healthChecksBuilder) {
        healthChecksBuilder.AddCheck<StaticGooglePubSubHealthCheck>("connection to static google pub sub");
    }
}