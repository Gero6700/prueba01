namespace Senator.As400.Cloud.Sync.Api.Options;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions> {
    private readonly IApiVersionDescriptionProvider provider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) {
        this.provider = provider;
    }

    public void Configure(SwaggerGenOptions options) {
        foreach (var description in provider.ApiVersionDescriptions) {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }

    public void Configure(string? name, SwaggerGenOptions options) {
        Configure(options);
    }

    private OpenApiInfo CreateVersionInfo(ApiVersionDescription desc) {
        var info = new OpenApiInfo {
            Title = "Senator AS400 Cloud Sync API",
            Version = desc.ApiVersion.ToString()
        };

        if (desc.IsDeprecated) {
            info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
        }

        return info;
    }
}