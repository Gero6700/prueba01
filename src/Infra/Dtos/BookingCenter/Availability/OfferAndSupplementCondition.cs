namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

//TODO: Poner nullables en los campos que lo necesiten
public class OfferAndSupplementCondition : IAggregateRoot {
    public bool Optional { get; set; }
    public StayType StayType { get; set; }
    public PaxType ApplyToPax { get; set; }
    public int MinStayDays { get; set; }
    public int MaxStayDays { get; set; }
    public int MinReleaseDays { get; set; }
    public int MaxReleaseDays { get; set; }
    public DateTime BookingWindowFrom { get; set; }
    public DateTime BookingWindowTo { get; set; }
    public string? OccupancyRateCod { get; set; } = string.Empty;
    public List<string> Rooms { get; set; } = new List<string>();
    public List<string> Regimes { get; set; } = new List<string>();
}
