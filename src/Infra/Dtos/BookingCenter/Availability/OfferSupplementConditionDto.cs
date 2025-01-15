namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class OfferSupplementConditionDto {
    public required StayType StayType { get; set; }
    public required PaxType ApplyToPax { get; set; }
    public int? MinStayDays { get; set; }
    public int? MaxStayDays { get; set; }
    public int? MinReleaseDays { get; set; }
    public int? MaxReleaseDays { get; set; }
    public DateTime? BookingWindowFrom { get; set; }
    public DateTime? BookingWindowTo { get; set; }
    public required string OnlyApplyIfRecordDatesOnWeekDays { get; set; }
    public required string OnlyApplyIfStayDatesOnWeekDays { get; set; }
    public required WeekDaysApplicationType WeekDaysApplicationMode { get; set; }
    public IEnumerable<string>? RoomCodes { get; set; }
    public IEnumerable<string>? MealCodes { get; set; }
}