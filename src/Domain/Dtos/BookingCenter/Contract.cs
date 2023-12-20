namespace Senator.As400.Cloud.Sync.Application.Dtos.BookingCenter;

public class Contract {
    public int Agency { get; set; }
    public int Branch { get; set; }
    public int HotelCode { get; set; }
    public string ContractCode { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}