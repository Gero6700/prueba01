using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class RestagenExtension {
    public static IntegrationClientTypeDto ToClientType(this Restagen restagen) {
        return new IntegrationClientTypeDto {
            Code = restagen.Mrcodi.ToString(),
            Description = restagen.Mrtext
        };
    }
}
