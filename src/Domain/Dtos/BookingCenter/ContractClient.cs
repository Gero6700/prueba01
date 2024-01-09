
namespace Senator.As400.Cloud.Sync.Application.Dtos.BookingCenter;
public class ContractClient {
    public string code { get; set; } = string.Empty;
    public decimal min_age_child { get; set; }
    public decimal max_age_child { get; set; }
    public decimal min_age_infant { get; set; }
    public decimal max_age_infant { get; set; }
    public decimal min_age_teenager { get; set; }
    public DateTime expired_date { get; set; }
    public decimal comission { get; set; }
    public IncomeType comission_type { get; set; }
    public string contract_code { get; set; } = string.Empty;
    public string client_code { get; set; } = string.Empty;

}
