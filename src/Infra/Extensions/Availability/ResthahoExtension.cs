using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ResthahoExtension {
    public static HotelRoomConfigurationDto ToHotelRoomConfiguration(this Resthaho resthaho) {
        return new HotelRoomConfigurationDto {
            HotelCode = resthaho.Tihote.ToString(),
            RoomCode = resthaho.Tihab,
            InventoryRoomTypeCode = resthaho.Tihabg,
            OccupancyRateCode = resthaho.Ticonf.ToString()
        };
    }
}
