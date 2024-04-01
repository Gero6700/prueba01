namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter;
public class OcuppancyRate {
    public string Code { get; set; } = string.Empty;
    public int MinAdult { get; set; }
    public int MinTeen { get; set; }
    public int MinChild { get; set; }
    public int MinInfant { get; set; }
    public int MaxAdult { get; set; }
    public int MaxTeen { get; set; }
    public int MaxChild { get; set; }
    public decimal MaxScore { get; set; }
    public decimal MinScore { get; set; }
}
