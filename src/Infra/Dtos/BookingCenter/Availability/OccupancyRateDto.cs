namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

public class OccupancyRateDto {
    public required string Code { get; set; }
    public int MinAdult { get; set; }
    public int MinTeen { get; set; }
    public int MinChild { get; set; }
    public int MinBaby { get; set; }
    public int MaxAdult { get; set; }
    public int MaxTeen { get; set; }
    public int MaxChild { get; set; }
    public int MaxBaby { get; set; }
    public decimal MaxScore { get; set; }
    public decimal MinScore { get; set; }
}