namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class StaticTax {
    public required string Code { get; set; } = string.Empty;
    public required string Description { get; set; } = string.Empty;
    public required decimal Amount { get; set; }
    public int Order { get; set; }
    public required bool AppliesToTaxableBase { get; set; }
}
