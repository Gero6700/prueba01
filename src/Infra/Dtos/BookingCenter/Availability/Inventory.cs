namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class Inventory {
    public DateTime InventoryDate { get; set; }
    public int RoomQuantity { get; set; }
    public int OccupiedRooms { get; set; }
    public string HotelCode { get; set; } = string.Empty;
    public string RoomCode { get; set; } = string.Empty;
}
