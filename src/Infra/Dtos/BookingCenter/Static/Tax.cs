namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class Tax{
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public TaxType Type { get; set; }
}
