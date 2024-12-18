namespace Senator.As400.Cloud.Sync.Api.Services {
    public static class HttpClientsService {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration) {
            AvailabilitySynchronizerHttpClient(services, configuration);
            return services;
        }

        private static void AvailabilitySynchronizerHttpClient(IServiceCollection services, IConfiguration configuration) {
            var availabilitySynchronizeApiClientSettings = configuration.GetSection("AvailabilitySynchronizerApi").Get<AvailabilitySynchronizerApiSettings>();
            services.AddHttpClient<IAvailabilitySynchronizerApiClient, AvailabilitySynchronizerApiClient>(client => {                
                client.BaseAddress = new Uri(configuration.GetSection("AvailabilitySynchronizerApi").Get<AvailabilitySynchronizerApiSettings>()!.BaseUrl);
            });
        }
    }
}
