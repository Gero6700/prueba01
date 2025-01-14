namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class CancellationPolicyDto {
    public required string Code { get; set; }
    public int? ReleaseDays { get; set; }
    public int? ReleaseHours { get; set; }
    public int? PenaltyNights { get; set; }
    public decimal? PenaltyPercent { get; set; }
    public decimal? PenaltyAmount { get; set; }
    public int ApplicationMargin { get; set; }
    public required CancellationPolicyApplicationType ApplicationType { get; set; }
    public bool ApplyInOfferPrice { get; set; }
    public bool ApplyIfInsurance { get; set; }
    public bool RefundAsBonus { get; set; }
    public IEnumerable<string>? IntegrationContractCodes { get; set; }
    public IEnumerable<string>? OfferSupplementCodes { get; set; }
}