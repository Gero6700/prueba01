
namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public interface IImageTranslationDto {
    string LanguageIsoCode { get; set; }
    string Title { get; set; }
    string? Description { get; set; }
}
