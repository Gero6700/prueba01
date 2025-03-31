namespace Senator.As400.Cloud.Sync.Api.Services;
public static class SqlServerDatabaseService {
    public static IServiceCollection AddSqlServerDatabase(this IServiceCollection services, IConfiguration configuration) {
        AddStaticDatabase(services, configuration);
        return services;
    }

    private static void AddStaticDatabase(IServiceCollection services, IConfiguration configuration) {

        try {
            var staticDatabaseConnectionString = configuration.GetConnectionString("StaticDatabase") ??
                                                   throw new SettingsNotFoundException("Static Database");
            services.AddScoped<IDbConnectionFactory>(sp => {
                return new DbConnectionFactory(() => {
                    var connection = new SqlConnection(staticDatabaseConnectionString);
                    //connection.Open();
                    return connection;
                });
            });
        }
        catch (Exception ex) {
            var errorMessage = ex.Message;
            var innerException = ex.InnerException;
            while (innerException != null) {
                errorMessage += $" - {innerException.Message}";
                innerException = innerException.InnerException;
            }

            throw new Exception($"Error adding static database: {errorMessage}");
        }

    }
}
