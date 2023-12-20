namespace Senator.As400.Cloud.Sync.Infrastructure.Http.Core;

public class HttpRequestMessageBuilder {
    private readonly string uri;
    private readonly HttpMethod method;
    private string? culture;
    private HttpContent? content;
    private string? clientToken;
    private string? mediaType;
    private string? bearerToken;

    public HttpRequestMessageBuilder(string uri, HttpMethod method) {
        this.uri = uri;
        this.method = method;
    }

    public HttpRequestMessageBuilder WithClientToken(string aClientToken) {
        clientToken = aClientToken;
        return this;
    }

    public HttpRequestMessageBuilder WithContent(HttpContent aContent) {
        content = aContent;
        return this;
    }

    public HttpRequestMessageBuilder WithMediaType(string aMediaType) {
        mediaType = aMediaType;
        return this;
    }

    public HttpRequestMessageBuilder WithBearerToken(string aBearearToken) {
        bearerToken = aBearearToken;
        return this;
    }

    public HttpRequestMessageBuilder WithCulture(string aCulture) {
        culture = aCulture;
        return this;
    }

    public HttpRequestMessage CreateHttpRequestMessage() {
        var httpRequestMessage = new HttpRequestMessage(method, uri);
        AddAcceptHeaderTo(httpRequestMessage);
        AddBearerTokenTo(httpRequestMessage);
        AddClientTokenTo(httpRequestMessage);
        AddCultureTo(httpRequestMessage);
        httpRequestMessage.Content = content;
        return httpRequestMessage;
    }

    private void AddAcceptHeaderTo(HttpRequestMessage httpRequestMessage) {
        if (string.IsNullOrEmpty(mediaType)) return;
        httpRequestMessage.Headers.Add("Accept", mediaType);
    }

    private void AddBearerTokenTo(HttpRequestMessage httpRequestMessage) {
        if (string.IsNullOrEmpty(bearerToken)) return;
        httpRequestMessage.SetBearerToken(bearerToken);
    }

    private void AddClientTokenTo(HttpRequestMessage httpRequestMessage) {
        if (string.IsNullOrEmpty(clientToken)) return;
        AddRequestHeader(httpRequestMessage, "Client-Token", clientToken);
    }

    private void AddCultureTo(HttpRequestMessage httpRequestMessage) {
        if (string.IsNullOrEmpty(culture)) return;
        AddRequestHeader(httpRequestMessage, "Accept-Language", culture);
    }

    private static void AddRequestHeader(HttpRequestMessage httpRequestMessage, string headerKey, string headerValue) {
        if (string.IsNullOrWhiteSpace(headerValue)) return;
        httpRequestMessage.Headers.Add(headerKey, headerValue);
    }
}