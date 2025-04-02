namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class CamaTipoExtension {
    public static IEnumerable<StaticRoomBedDto>? ToRoomBedDto(this IEnumerable<CamaTipo> camas) {
        if (!camas.Any()) {
            return null;
        }
        return camas.Select(cama => new StaticRoomBedDto {
            Width = cama.AnchoCm,
            Height = cama.AltoCm,
            RoomBedTranslations = GetTranslations(cama)
        }).ToList();
    }
    private static List<StaticRoomBedTranslationDto> GetTranslations(CamaTipo cama) {
        var translations = new List<StaticRoomBedTranslationDto>();
        var descriptions = new Dictionary<Language, string> {
            { Language.Es, cama.EsNombre },
            { Language.En, cama.EnNombre },
            { Language.Fr, cama.FrNombre },
            { Language.De, cama.DeNombre },
            { Language.Pt, cama.PtNombre }
        };
        foreach (var language in Enum.GetValues<Language>()) {
            if (!descriptions.TryGetValue(language, out var description)) {
                continue;
            }
            if (string.IsNullOrEmpty(description)) {
                continue;
            }
            translations.Add(new StaticRoomBedTranslationDto {
                LanguageIsoCode = language.GetIsoCode(),
                Description = description
            });
        }
        return translations;
    }
}
