namespace Senator.As400.Cloud.Sync.Application.Dtos.BookingCenter;

public class ContractClient {
    public string Code { get; set; } = string.Empty;
    public double MinAgeOfBabies { get; set; }
    public double MaxAgeOfBabies { get; set; }
    public double MinAgeOfChildren { get; set; }
    public double MaxAgeChildren { get; set; }
    public double MinAgeOfTeenagers { get; set; }
    public double MaxAgeOfTeenagers { get; set; }
    public DateTime ExpiredDate { get; set; }
    public decimal Comission { get; set; }
    public IncomeType ComissionType { get; set; }
    public string ContractCode { get; set; } = string.Empty;
    public string ClientCode { get; set; } = string.Empty;
}