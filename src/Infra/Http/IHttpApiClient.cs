namespace Senator.As400.Cloud.Sync.Infrastructure.Http;

public interface IHttpApiClient {
    Task<TK> PostAsJson<T, TK>(string uri, T body);
    Task PostAsJson<T>(string uri, T body);
}