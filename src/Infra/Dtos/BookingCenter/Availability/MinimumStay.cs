namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;
public class MinimumStay {
    public string Code { get; set; } = string.Empty;
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public int Days { get; set; }
    public bool StrictPeriod { get; set; }
    public string ContractClientCode { get; set; } = string.Empty;
    public string? RoomCode { get; set; } = string.Empty;
    public string? RegimeCode { get; set; } = string.Empty;
}
