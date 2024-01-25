namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class RestagenExtension {
    public static ClientType ToClientType(this Restagen restagen) {
        return new ClientType {
            Code = restagen.Mrcodi.ToString(),
            Description = restagen.Mrtext
        };
    }
}
