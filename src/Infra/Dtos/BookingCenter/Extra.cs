namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter;
public class Extra:IAggregateRoot {
    public string Code { get; set; } = string.Empty;
    public DateTime ApplyFrom { get; set; }
    public DateTime ApplyTo { get; set; }
    public DateTime CheckInFrom { get; set; }
    public DateTime CheckInTo { get; set; }
    public int StayFrom { get; set; }
    public int StayTo { get; set; }
    public bool Mandatory { get; set; }
    public int Quantity { get; set; }
    public int ByDay { get; set; }
    public ApplyStayPriceType ApplyBy { get; set; }
    public decimal Price { get; set; }
    public ApplyStayPriceType PriceApplication { get; set; }
    public ApplyOtherSuplementsOrDiscounts ApplyOtherSuplementsOrDiscounts { get; set; }
    public bool IsCancellationGuarantee { get; set; }
    public string OccupancyRateCod { get; set; } = string.Empty;
    public List<ExtraPax> Paxes { get; set; } = new List<ExtraPax>();
    public List<string> Rooms { get; set; } = new List<string>();
    public List<string> Regimes { get; set; } = new List<string>();
}
