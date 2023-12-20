namespace Senator.As400.Cloud.Sync.Infrastructure.Http;

public class NoAuthHttpApiClient : IHttpApiClient {
    private readonly HttpClient httpClient;

    public NoAuthHttpApiClient(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public async Task PostAsJson<T>(string uri, T body) {
        await Post(uri, body, "application/json");
    }

    public async Task<TK> PostAsJson<T, TK>(string uri, T body) {
        return await ExtractResponseContent<TK>(await Post(uri, body, "application/json"));
    }
    
    private async Task<HttpResponseMessage> Post<T>(string uri, T body, string mediaType) {
        var payload = await Task.Run(() => JsonSerializer.Serialize(body));
        var httpRequestMessageBuilder = new HttpRequestMessageBuilder(uri, HttpMethod.Post)
            .WithMediaType(mediaType)
            .WithContent(new StringContent(payload, Encoding.UTF8, mediaType));
        return await ExecuteRequest(httpRequestMessageBuilder);
    }

    private async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessageBuilder requestBuilder) {
        var request = requestBuilder.CreateHttpRequestMessage();
        var response = await httpClient.SendAsync(request);
        if (!response.IsSuccessStatusCode) {
            throw new HttpException(response, new Exception(response.Content.ReadAsStringAsync().Result));
        }
        return response;
    }

    private static async Task<T> ExtractResponseContent<T>(HttpResponseMessage response) {
        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync())!;
    }
}