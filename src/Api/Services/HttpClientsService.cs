using System.Text.Json;

namespace Senator.As400.Cloud.Sync.Api.Services {
    public static class HttpClientsService {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration) {
            AvailabilitySynchronizerHttpClient(services, configuration);
            StaticDataSynchronizerHttpClient(services, configuration);
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
    }
}
