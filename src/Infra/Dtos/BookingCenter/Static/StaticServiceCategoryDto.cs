namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class StaticServiceCategoryDto {
    public required string Code { get; set; }
    public IEnumerable<StaticServiceCategoryTranslationDto>? ServiceCategoryTranslations { get; set; }
}
public class StaticServiceCategoryTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Name { get; set; }
}