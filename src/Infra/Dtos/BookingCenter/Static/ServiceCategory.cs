namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class ServiceCategory : IAggregateRoot {
    public string Code { get; set; } = string.Empty;
    public List<Translation> Translations { get; set; } = [];
}
