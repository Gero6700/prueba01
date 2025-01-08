namespace Availability.Synchronizer.Api.Dtos;

public class HotelRoomConfigurationDto {
    public required string HotelCode { get; set; }
    public required string RoomCode { get; set; }
    public string? OccupancyRateCode { get; set; }
    public string? InventoryRoomTypeCode { get; set; }
}