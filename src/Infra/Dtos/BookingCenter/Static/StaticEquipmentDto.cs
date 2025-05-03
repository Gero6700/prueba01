namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;
public class StaticEquipmentDto {
    public required string Name { get; set; }
    public IEnumerable<EquipmentTranslationDto>? EquipmentTranslations { get; set; }
}

public class EquipmentTranslationDto {
    public required string LanguageIsoCode { get; set; }
    public required string Description { get; set; }
}
