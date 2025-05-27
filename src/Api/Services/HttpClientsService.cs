namespace Senator.As400.Cloud.Sync.Api.Services {
    public static class HttpClientsService {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration) {
            AvailabilitySynchronizerHttpClient(services, configuration);
            StaticDataSynchronizerHttpClient(services, configuration);
            As400NotificationHttpClient(services, configuration);
            return services;
        }

        private static void AvailabilitySynchronizerHttpClient(IServiceCollection services, IConfiguration configuration) {
            var availabilitySynchronizeApiClientSettings = configuration.GetSection("AvailabilitySynchronizerApi").Get<AvailabilitySynchronizerApiSettings>();
            var hotelChainSettings = configuration.GetSection("HotelChain").Get<HotelChainSettings>();
           
            services.AddHttpClient<IAvailabilitySynchronizerApiClient, AvailabilitySynchronizerApiClient>(client => {                
                client.BaseAddress = new Uri(availabilitySynchronizeApiClientSettings!.BaseUrl);
                client.DefaultRequestHeaders.Add("Hotel-Chain-Id", hotelChainSettings!.Id);
            });
        }

        private static void StaticDataSynchronizerHttpClient(IServiceCollection services, IConfiguration configuration) {
            var staticSynchronizeApiClientSettings = configuration.GetSection("StaticDataSynchronizerApi").Get<AvailabilitySynchronizerApiSettings>();
            var hotelChainSettings = configuration.GetSection("HotelChain").Get<HotelChainSettings>();
            
            services.AddHttpClient<IStaticSynchronizerApiClient, StaticSynchronizerApiClient>(client => {
                client.BaseAddress = new Uri(staticSynchronizeApiClientSettings!.BaseUrl);
                client.DefaultRequestHeaders.Add("Hotel-Chain-Id", hotelChainSettings!.Id);
            });
        }

        private static void As400NotificationHttpClient(IServiceCollection services, IConfiguration configuration) {
            var as400NotificationApiClientSettings = configuration.GetSection("As400NotificationApi").Get<As400NotificationApiSettings>();
            var hotelChainSettings = configuration.GetSection("HotelChain").Get<HotelChainSettings>();
            services.AddHttpClient<IAs400NotificationApiClient, As400NotificationApiClient>(client => {
                client.BaseAddress = new Uri(as400NotificationApiClientSettings!.BaseUrl);
            });
        }
    }
}
