namespace Senator.As400.Cloud.Sync.Api.Services; 

public static class HealthChecksService {
    public static IServiceCollection AddHealthChecksService(this IServiceCollection services, 
        IConfiguration configuration) {
        var healthChecksBuilder = services.AddHealthChecks();
        AddAvailGooglePubSubHealthCheck(healthChecksBuilder);
        AddQuotaGooglePubSubHealthCheck(healthChecksBuilder);
        AddStaticGooglePubSubHealthCheck(healthChecksBuilder);
        AddStaticDatabaseHealthCheck(healthChecksBuilder, configuration);
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

    private static void AddStaticDatabaseHealthCheck(IHealthChecksBuilder healthChecksBuilder, 
        IConfiguration configuration) {
        //healthChecksBuilder.AddCheck<StaticDatabaseHealthCheck>("connection to static database");
        var staticDbConnectionString = configuration.GetConnectionString("StaticDatabase");
        if (string.IsNullOrWhiteSpace(staticDbConnectionString))
            throw new InvalidOperationException("La cadena de conexión 'StaticDatabase' no está configurada.");

        healthChecksBuilder.AddSqlServer(
            staticDbConnectionString,
            name: "connection to static database"
        );
    }
}