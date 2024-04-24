namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class Bed : IAggregateRoot {
    public int Width { get; set; }
    public int Length { get; set; }
    public List<Translation> Translations { get; set; } = [];
}
