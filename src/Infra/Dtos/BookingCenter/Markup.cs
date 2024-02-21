namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter;
public class Markup {
    public string Code { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime BookingWindowFrom { get; set; }
    public DateTime BookingWindowTo { get; set; }
    public DateTime StayFrom { get; set; }
    public DateTime StayTo { get; set; }
    public decimal Amount { get; set; }
}
