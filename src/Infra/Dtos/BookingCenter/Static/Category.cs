namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class Category : IAggregateRoot {
    public string Code { get; set; } = string.Empty;
    public List<Translation> Translations { get; set; } = new List<Translation>();
}
