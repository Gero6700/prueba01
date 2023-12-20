namespace Senator.As400.Cloud.Sync.Api.Services; 

public static class HealthChecksService {
    public static IServiceCollection AddHealthChecksService(this IServiceCollection services) {
        var healthChecksBuilder = services.AddHealthChecks();
        AddAvailabilitySynchronizerApiHealthCheck(healthChecksBuilder);
        AddBookingSynchronizerApiHealthCheck(healthChecksBuilder);
        return services;
    }
    
    private static void AddAvailabilitySynchronizerApiHealthCheck(IHealthChecksBuilder healthChecksBuilder) {
        healthChecksBuilder.AddCheck<AvailabilitySynchronizerApiHealthCheck>("connection to availability synchronizer api");
    }

    private static void AddBookingSynchronizerApiHealthCheck(IHealthChecksBuilder healthChecksBuilder) {
        healthChecksBuilder.AddCheck<BookingSynchronizerApiHealthCheck>("connection to booking synchronizer api");
    }

    private static void AddStaticDataSynchronizerApiHealthCheck(IHealthChecksBuilder healthChecksBuilder) {
        healthChecksBuilder.AddCheck<StaticDataSynchronizerApiHealthCheck>("connection to static data synchronizer api");
    }
}