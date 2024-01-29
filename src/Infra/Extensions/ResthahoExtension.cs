namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ResthahoExtension {
    public static HotelRoomConfiguration ToHotelRoomConfiguration(this Resthaho resthaho) {
        return new HotelRoomConfiguration {
            HotelCode = resthaho.Tihote.ToString(),
            RoomCode = resthaho.Tihab,
            InventoryRoomTypeCode = resthaho.Tihabg,
            OcuppancyRateCode = resthaho.Ticonf.ToString()
        };
    }
}
