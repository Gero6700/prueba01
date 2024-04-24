namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class Equipment : IAggregateRoot {
    public string Name { get; set; } = string.Empty;
    public List<Translation> Translations { get; set; } = [];   
}
