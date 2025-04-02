namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public interface IImageDto {
    int Order { get; set; }
    string Url { get; set; }
    IEnumerable<StaticImageTranslationDto>? ImageTranslations { get; set; }
}
