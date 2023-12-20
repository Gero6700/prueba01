namespace Senator.As400.Cloud.Sync.Infrastructure.Http;

public class OAuth2HttpApiClient : IHttpApiClient {
    private readonly string authorizationServerUrl;
    private readonly string clientId;
    private readonly string clientSecret;
    private readonly string apiId;
    private readonly HttpClient httpClient;
    private readonly OAuth2Policy oAuth2Policy;
    private DiscoveryDocumentResponse discoveryDocumentResponse = new();
    private string authToken = string.Empty;

    public OAuth2HttpApiClient(string authorizationServerUrl, string clientId, string clientSecret, string apiId,
        HttpClient httpClient, OAuth2Policy? oAuth2Policy) {
        this.authorizationServerUrl = authorizationServerUrl;
        this.clientId = clientId;
        this.clientSecret = clientSecret;
        this.apiId = apiId;
        this.httpClient = httpClient;
        this.oAuth2Policy = oAuth2Policy ?? new OAuth2Policy();
    }

    public async Task PostAsJson<T>(string uri, T body) {
        await Post(uri, body, MediaTypes.JsonMediaType);
    }

    public async Task<TK> PostAsJson<T, TK>(string uri, T body) {
        var response = await Post(uri, body, MediaTypes.JsonMediaType);
        return await ExtractResponseContent<TK>(response);
    }
    
    private async Task<HttpResponseMessage> Post<T>(string uri, T body, string mediaType) {
        var payload = await Task.Run(() => JsonSerializer.Serialize(body));
        var httpRequestBuilder = new HttpRequestMessageBuilder(uri, HttpMethod.Post)
            .WithBearerToken(await GetAccessToken())
            .WithMediaType(mediaType)
            .WithContent(new StringContent(payload, Encoding.UTF8, mediaType));
        return await ExecuteAuthorizedRequest(httpRequestBuilder);
    }

    private static async Task<T> ExtractResponseContent<T>(HttpResponseMessage response) {
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content)!;
    }

    private async Task<HttpResponseMessage> ExecuteAuthorizedRequest(HttpRequestMessageBuilder requestBuilder) {
        var response = await httpClient.SendAsync(requestBuilder.CreateHttpRequestMessage());
        if (IsUnauthorized(response)) {
            var token = await RefreshAuthToken(discoveryDocumentResponse);
            var request = requestBuilder.CreateHttpRequestMessage();
            request.SetBearerToken(token);
            response = await httpClient.SendAsync(request);
        }
        if (!response.IsSuccessStatusCode) {
            throw new HttpException(response, new Exception(response.Content.ReadAsStringAsync().Result));
        }
        return response;
    }

    private async Task<string> GetAccessToken() {
        if (!string.IsNullOrEmpty(authToken)) return authToken;
        discoveryDocumentResponse = await GetDiscoveryDocumentResponse();
        if (discoveryDocumentResponse.IsError) {
            throw new HttpRequestException(discoveryDocumentResponse.Error, discoveryDocumentResponse.Exception);
        }
        return await RefreshAuthToken(discoveryDocumentResponse);
    }

    protected virtual async Task<DiscoveryDocumentResponse> GetDiscoveryDocumentResponse() {
        return await httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest {
            Address = authorizationServerUrl,
            Policy = {
                RequireHttps = oAuth2Policy.RequireHttps,
                ValidateEndpoints = oAuth2Policy.ValidateEndpoints,
                ValidateIssuerName = oAuth2Policy.ValidateIssuerName
            }
        });
    }

    private async Task<string> RefreshAuthToken(DiscoveryDocumentResponse aDiscoveryDocumentResponse) {
        var clientCredentialsTokenRequest = CreateClientCredentialsTokenRequest(aDiscoveryDocumentResponse);
        var tokenResponse = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialsTokenRequest);
        
        if (tokenResponse.IsError) {
            throw new HttpRequestException(tokenResponse.Error, tokenResponse.Exception);
        }

        authToken = tokenResponse.AccessToken!;
        return authToken;
    }

    protected virtual ClientCredentialsTokenRequest CreateClientCredentialsTokenRequest(
        DiscoveryDocumentResponse aDiscoveryDocumentResponse) {
        return new ClientCredentialsTokenRequest {
            Address = aDiscoveryDocumentResponse.TokenEndpoint,
            ClientId = clientId,
            ClientSecret = clientSecret,
            Scope = apiId
        };
    }

    protected virtual bool IsUnauthorized(HttpResponseMessage response) {
        return response.StatusCode == HttpStatusCode.Unauthorized;
    }
}