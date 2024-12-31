namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class ContractClient {
    public string Code { get; set; } = string.Empty;
    public bool ClosingSales { get; set; }
    public decimal MinAgeOfBabies { get; set; }
    public decimal MaxAgeOfBabies { get; set; }
    public decimal MinAgeOfChildren { get; set; }
    public decimal MaxAgeChildren { get; set; }
    public decimal MinAgeOfTeenagers { get; set; }
    public decimal MaxAgeOfTeenagers { get; set; }
    public DateTime? ExpiredDate { get; set; }
    public decimal Comission { get; set; }
    public bool IsPvp { get; set; }
    public decimal CancellationGuarantee { get; set; }
    public bool CancellationGuaranteeIsCommissionable { get; set; }
    public string ContractCode { get; set; } = string.Empty;
    public string ClientCode { get; set; } = string.Empty;
}