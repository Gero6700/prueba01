namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class InventoryDto {
    public required DateTime InventoryDate { get; set; }
    public required int RoomQuantity { get; set; }
    public required int OccupiedRooms { get; set; }
    public required DateTime LastUpdateDate { get; set; }
    public required string HotelCode { get; set; } = string.Empty;
    public required string RoomCode { get; set; } = string.Empty;
}