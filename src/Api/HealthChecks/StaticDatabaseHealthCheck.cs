
namespace Senator.As400.Cloud.Sync.Api.HealthChecks;
public class StaticDatabaseHealthCheck : IHealthCheck {
    private readonly IConfiguration configuration;

    public StaticDatabaseHealthCheck(IConfiguration configuration) {
        this.configuration = configuration;
    }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) {
        throw new NotImplementedException();
    }

    private bool CheckStaticDatabase() {
        var staticDatabaseSettings = configuration.GetConnectionString("StaticDatabase");
        CheckIfStaticDatabaseSettingsExist(staticDatabaseSettings);
        try {
            // Aquí se implementaría la lógica para verificar la conexión a la base de datos estática
            // Por ejemplo, podrías intentar abrir una conexión a la base de datos
            return TestDatabaseConnection(staticDatabaseSettings);
        }
        catch (Exception) {
            return false; // Si ocurre un error, la base de datos no está accesible
        }
    }

    private static void CheckIfStaticDatabaseSettingsExist(string? staticDatabaseSettings) {
        if (string.IsNullOrEmpty(staticDatabaseSettings)) {
            throw new SettingsNotFoundException("Static Database settings do not exist");
        }
    }
}
