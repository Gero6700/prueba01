namespace Senator.As400.Cloud.Sync.Infrastructure.Http.Core;

public class OAuth2Policy {
    public bool RequireHttps { get; set; } = false;
    public bool ValidateEndpoints { get; set; } = true;
    public bool ValidateIssuerName { get; set; } = true;
}