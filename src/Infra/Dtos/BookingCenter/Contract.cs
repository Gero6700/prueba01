namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter;

public class Contract {
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ValidDateFrom { get; set; }
    public DateTime ValidDateTo { get; set; }
    public bool TaxIncluded { get; set; }
    public TypeOfAgeOrdering TypeOfAgeOrdering { get; set; }
    public DateTime? DepositDate { get; set; }
    public decimal DepositAmount { get; set; }
    public DepositType DepositType { get; set; }
    public int HotelCode { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
    public string Market { get; set; } = string.Empty;
}