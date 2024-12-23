using System.Text.Json;

namespace Senator.As400.Cloud.Sync.Api.Services {
    public static class HttpClientsService {
        public static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration) {
            AvailabilitySynchronizerHttpClient(services, configuration);
            return services;
        }

        private static void AvailabilitySynchronizerHttpClient(IServiceCollection services, IConfiguration configuration) {
            var availabilitySynchronizeApiClientSettings = configuration.GetSection("AvailabilitySynchronizerApi").Get<AvailabilitySynchronizerApiSettings>();
            var hotelChainSettings = configuration.GetSection("HotelChain").Get<HotelChainSettings>();
            var userInfo = new UserInfo {
                IntegrationType = string.Empty,
                HotelChainId = hotelChainSettings!.Id,
                ChannelManager = string.Empty,
                Channel = string.Empty,
                ChannelUsername = string.Empty,
                ChannelPassword = string.Empty
            };
            services.AddHttpClient<IAvailabilitySynchronizerApiClient, AvailabilitySynchronizerApiClient>(client => {                
                client.BaseAddress = new Uri(availabilitySynchronizeApiClientSettings!.BaseUrl);
                //TODO: Ver las cabeceras con Jesus
                client.DefaultRequestHeaders.Add("Username", hotelChainSettings!.Username);
                client.DefaultRequestHeaders.Add("UserInfo", JsonSerializer.Serialize<UserInfo>(new UserInfo()));
            });
        }

        public class UserInfo {
            public string IntegrationType { get; set; } = string.Empty;
            public string HotelChainId { get; set; } = string.Empty;
            public string ChannelManager { get; set; } = string.Empty;
            public string Channel { get; set; } = string.Empty;
            public string ChannelUsername { get; set; } = string.Empty;
            public string ChannelPassword { get; set; } = string.Empty;
        }
    }
}
