namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class Image : IAggregateRoot{
    public int Order { get; set; }
    public string Url { get; set; } = string.Empty;
    public List<ImageTranslation> Translations { get; set; } = [];
}
