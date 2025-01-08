namespace Availability.Synchronizer.Api.Dtos;

public class OccupancyScoreDto {
    public decimal? Adults { get; set; }
    public decimal? Teenagers { get; set; }
    public decimal? Children { get; set; }
    public decimal? Babies { get; set; }
}