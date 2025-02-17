namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class PeriodPricingDto {
    public required string Code { get; set; }
    public required bool ClosingSales { get; set; }
    public required string RateCode { get; set; }
    public required DateTime PricingDate { get; set; }
    public required decimal StayPvp { get; set; }
    public required string StayPvpApplyMode { get; set; }
    public required decimal MealPvp { get; set; }
    public required string MealPvpApplyMode { get; set; }
    public bool? OnRequest { get; set; }
    public int? Release { get; set; }
    public required string IntegrationContractCode { get; set; }
    public required string RoomCode { get; set; }
    public required string MealCode { get; set; }
}