namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class OfferSupplementConfigurationDto {
    public int? FreeDays { get; set; }
    public ApplyStayPriceType? ApplyStayPriceType { get; set; }
    public decimal? ApplyStayPrice { get; set; }
    public ApplyStayPriceType? ApplyMealPriceType { get; set; }
    public decimal? ApplyMealPrice { get; set; }
    public decimal Amount { get; set; }
    public required TypeOfPayment AmountType { get; set; }
    public required DiscountTargetType Target { get; set; }
    public required DiscountScopeType Scope { get; set; }
    public string? RoomUsedToCalculatePrice { get; set; }
    public string? MealUsedToCalculatePrice { get; set; }
}