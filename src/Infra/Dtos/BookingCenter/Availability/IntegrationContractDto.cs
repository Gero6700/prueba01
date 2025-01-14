namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class IntegrationContractDto {
    public required string Code { get; set; }
    public bool ClosingSales { get; set; }
    public decimal? MinAgeTeenager { get; set; }
    public decimal? MaxAgeTeenager { get; set; }
    public decimal MinAgeChild { get; set; }
    public decimal MaxAgeChild { get; set; }
    public decimal? MinAgeBaby { get; set; }
    public decimal? MaxAgeBaby { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public bool IsGuaranteedQuota { get; set; }
    public decimal Commission { get; set; }
    public bool IsPvp { get; set; }
    public decimal CancellationGuarantee { get; set; }
    public bool CancellationGuaranteeIsCommissionable { get; set; }
    public required string ContractHeaderCode { get; set; }
    public required string IntegrationCode { get; set; }
}