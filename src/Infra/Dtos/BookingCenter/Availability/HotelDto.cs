namespace Availability.Synchronizer.Api.Dtos;

public class HotelDto {
    public required string Code { get; set; }
    public required string TimeZone { get; set; }
    public required string ProvinceCode { get; set; }
    public required string CityCode { get; set; }
}