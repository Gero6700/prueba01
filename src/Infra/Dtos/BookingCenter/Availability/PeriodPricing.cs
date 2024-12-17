namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;
public class PeriodPricing {
    public bool ClosingSales { get; set; }
    public string RateCode { get; set; } = string.Empty;
    public DateTime PricingDate { get; set; }
    public decimal StayPvp { get; set; }
    public ApplyStayPriceType StayPvpApplyMode { get; set; }
    public decimal RegimePvp { get; set; }
    public ApplyStayPriceType RegimePvpApplyMode { get; set; }
    public bool OnRequest { get; set; }
    public int Release { get; set; }
    public string RoomCode { get; set; } = string.Empty;
    public string RegimeCode { get; set; } = string.Empty;
    public string IntegrationContractId { get; set; } = string.Empty;
}
