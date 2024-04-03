using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class ReshotelExtension {
    public static Hotel ToHotel(this Reshotel resHotel) {
        return new Hotel {
            Code = resHotel.Hotcod.ToString(),
            TimeZone = resHotel.Hozhor,
            ProvinceCode = resHotel.ProvinceCode,
            CityCode = resHotel.CityCode,
        };
    }
}
