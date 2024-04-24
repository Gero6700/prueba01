namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class ReshotelExtension {
    public static Dtos.BookingCenter.Availability.Hotel ToHotel(this Reshotel resHotel) {
        return new Dtos.BookingCenter.Availability.Hotel
        {
            Code = resHotel.Hotcod.ToString(),
            TimeZone = resHotel.Hozhor,
            ProvinceCode = resHotel.ProvinceCode,
            CityCode = resHotel.CityCode,
        };
    }
}
