namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class ExtraDto {
    public required string Code { get; set; }
    public DateTime? ApplyFrom { get; set; }
    public DateTime? ApplyTo { get; set; }
    public DateTime CheckInFrom { get; set; }
    public DateTime CheckInTo { get; set; }
    public int? StayFrom { get; set; }
    public int? StayTo { get; set; }
    public bool Mandatory { get; set; }
    public int Quantity { get; set; }
    public int ByDay { get; set; }
    public required ApplyStayPriceType ApplyBy { get; set; }
    public decimal Price { get; set; }
    public required ApplyStayPriceType PriceApplication { get; set; }
    public bool TaxesIncluded { get; set; }
    public required ExtrasDiscountApplicationType DiscountApplicationType { get; set; }
    public bool IsCommissionable { get; set; }
    public string? OccupancyRateCode { get; set; }
    public required IEnumerable<ExtraPaxDto> ExtraPaxes { get; set; }
    public IEnumerable<string>? IntegrationContractCodes { get; set; }
    public IEnumerable<string>? RoomCodes { get; set; }
    public IEnumerable<string>? MealCodes { get; set; }
    public IEnumerable<string>? OfferSupplementCodes { get; set; }
}