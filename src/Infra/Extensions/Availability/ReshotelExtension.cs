namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class ReshotelExtension {
    public static HotelDto ToHotel(this Reshotel resHotel) {
        return new HotelDto {
            Code = resHotel.Hotcod,
            TimeZone = resHotel.Hozhor,
            ProvinceCode = resHotel.Hotpri,
            CityCode = resHotel.HotPoi,
        };
    }
}
