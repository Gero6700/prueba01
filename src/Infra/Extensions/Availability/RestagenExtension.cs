using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class RestagenExtension {
    public static ClientType ToClientType(this Restagen restagen) {
        return new ClientType {
            Code = restagen.Mrcodi.ToString(),
            Description = restagen.Mrtext
        };
    }
}
