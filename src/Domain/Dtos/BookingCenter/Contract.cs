namespace Senator.As400.Cloud.Sync.Application.Dtos.BookingCenter;

public class Contract {
    public string code { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public DateTime valid_date_from { get; set; }
    public DateTime valid_date_to { get; set; }
    public bool tax_included { get; set; }
    public OrderedAges ordered_ages { get; set; }
    public DateTime deposit_date { get; set; }
    public decimal deposit_amount { get; set; }
    public DepositType deposit_type { get; set; }
    public int hotel_code { get; set; }
    public string currency_code { get; set; } = string.Empty;
    public string market { get; set; } = string.Empty;
}