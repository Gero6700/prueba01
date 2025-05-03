namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class StaticServiceDto {
    public required string Code { get; set; }
    public string? ServiceCategoryCode { get; set; }
    public IEnumerable<StaticServiceTranslationDto>? ServiceTranslations { get; set; }
}

public class StaticServiceTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
}
