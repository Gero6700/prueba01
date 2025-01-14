namespace Availability.Synchronizer.Api.Dtos;

public class OfferSupplementConfigurationDto {
    public required string Code { get; set; }
    public int? FreeDays { get; set; }
    public string? ApplyStayPriceType { get; set; }
    public decimal? ApplyStayPrice { get; set; }
    public string? ApplyMealPriceType { get; set; }
    public decimal? ApplyMealPrice { get; set; }
    public decimal Amount { get; set; }
    public required string AmountType { get; set; }
    public required string Target { get; set; }
    public required string Scope { get; set; }
    public string? RoomUsedToCalculatePrice { get; set; }
    public string? MealUsedToCalculatePrice { get; set; }
}