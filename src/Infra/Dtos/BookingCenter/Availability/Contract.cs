namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class Contract {
    public string Code { get; set; } = string.Empty;
    public bool ClosingSales { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime ValidDateFrom { get; set; }
    public DateTime ValidDateTo { get; set; }
    public bool TaxIncluded { get; set; }
    public TypeOfAgeOrdering TypeOfAgeOrdering { get; set; }
    public DateTime? DepositDate { get; set; }
    public decimal DepositAmount { get; set; }
    public DepositType DepositType { get; set; }
    public string HotelCode { get; set; } = string.Empty;
    public string CurrencyIsoCode { get; set; } = string.Empty;
    public string MarketCode { get; set; } = string.Empty;
}