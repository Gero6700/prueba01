namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public interface IAs400NotificationApiClient {
    Task<HttpResponseMessage> SendNotification(string tabla, string id, string fechaModi, string status, string text);
}
