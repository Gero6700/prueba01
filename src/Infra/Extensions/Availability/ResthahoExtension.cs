using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ResthahoExtension {
    public static HotelRoomConfiguration ToHotelRoomConfiguration(this Resthaho resthaho) {
        return new HotelRoomConfiguration {
            HotelCode = resthaho.Tihote.ToString(),
            RoomCode = resthaho.Tihab,
            InventoryRoomTypeCode = resthaho.Tihabg,
            OccupancyRateCode = resthaho.Ticonf.ToString()
        };
    }
}
