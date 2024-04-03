namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class CancellationPolicyLine : IAggregateRoot {
    public string Code { get; set; } = string.Empty;
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public int ReleaseDays { get; set; }
    public int ReleaseHours { get; set; }
    public int PenaltyNights { get; set; }
    public decimal PenaltyPercent { get; set; }
    public decimal PenaltyAmount { get; set; }
    public int ApplicationMargin { get; set; }
    public CancellationPolicyApplicationType ApplicationType { get; set; }
    public bool ApplyInOfferPrice { get; set; }
    public bool ApplyIfInsurance { get; set; }
    public bool RefundAsBonus { get; set; }
    public List<string> OffersAndSuplements { get; set; } = new List<string>();
    public List<string> ContractClients { get; set; } = new List<string>();
}
