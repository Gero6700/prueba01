
namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public class As400NotificationApiClient : IAs400NotificationApiClient {
    private readonly HttpClient httpClient;

    public As400NotificationApiClient(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public Task<HttpResponseMessage> SendNotification(string tabla, string id, string fechaModi, string status) {
        return httpClient.GetAsync($"web/services/EstadoSincroPubSub?Tabla={tabla}&Id={id}&FechaModi={fechaModi:yyyy-MM-ddTHH:mm:ss.ffffffZ}&Status={status}");
    }
}
