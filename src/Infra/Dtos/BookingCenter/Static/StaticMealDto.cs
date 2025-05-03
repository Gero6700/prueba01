namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class StaticMealDto {
    public required string Code { get; set; }
    public required IEnumerable<StaticMealTranslationDto>? MealTranslations { get; set; }
}

public class StaticMealTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Name { get; set; }
}
