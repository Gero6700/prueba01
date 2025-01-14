namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class ContractHeaderDto {
    public required string Code { get; set; }
    public string? Description { get; set; }
    public required bool ClosingSales { get; set; }
    public required DateTime ValidDateFrom { get; set; }
    public required DateTime ValidDateTo { get; set; }
    public required bool TaxIncluded { get; set; }
    public required TypeOfAgeOrdering OrderedAges { get; set; }
    public DateTime? DepositDate { get; set; }
    public decimal? DepositAmount { get; set; }
    public DepositType? DepositType { get; set; }
    public required bool BabiesFree { get; set; }
    public required string CurrencyIsoCode { get; set; }
    public required string HotelCode { get; set; }
    public required string MarketCode { get; set; }
}