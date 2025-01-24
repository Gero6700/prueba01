namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class PeriodPricingPaxDto {
    public required string Code { get; set; }
    public required int PaxOrder { get; set; }
    public required PaxType PaxType { get; set; }
    public required ScopeType Scope { get; set; }
    public decimal? AgeFrom { get; set; }
    public decimal? AgeTo { get; set; }
    public required decimal Amount { get; set; }
    public required TypeOfPayment AmountType { get; set; }
    public required string PeriodPricingCode { get; set; }
}