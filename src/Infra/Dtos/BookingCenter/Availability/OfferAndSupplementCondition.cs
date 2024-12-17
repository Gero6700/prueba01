namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class OfferAndSupplementCondition : IAggregateRoot {
    public StayType StayType { get; set; }
    public PaxType ApplyToPax { get; set; }
    public int? MinStayDays { get; set; }
    public int? MaxStayDays { get; set; }
    public int? MinReleaseDays { get; set; }
    public int? MaxReleaseDays { get; set; }
    public DateTime? BookingWindowFrom { get; set; }
    public DateTime? BookingWindowTo { get; set; }
    public string OnlyApplyIfRecordDatesOnWeekDays { get; set; } = string.Empty;
    public string OnlyApplyIfStayDatesOnWeekDays { get; set; } = string.Empty;
    public WeekDaysApplicationType WeekDaysApplicationMode { get; set; }
    public string? OccupancyRateCod { get; set; }
    public List<string> Rooms { get; set; } = [];
    public List<string> Regimes { get; set; } = [];
}
