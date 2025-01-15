namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class HotelRoomConfigurationDto {
    public required string HotelCode { get; set; }
    public required string RoomCode { get; set; }
    public string? OccupancyRateCode { get; set; }
    public required string InventoryRoomTypeCode { get; set; }
}