namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class RegimenExtension {
    public static IEnumerable<StaticMealDto> ToMealDto(this IEnumerable<Regimen> regimenes) {
        if (!regimenes.Any()) {
            return [];
        }

        return regimenes.Select(regimen => new StaticMealDto {
            Code = regimen.Codigo,
            MealTranslations = GetTranslations(regimen)
        });
    }

    private static List<StaticMealTranslationDto> GetTranslations(Regimen regimen) {
        var translations = new List<StaticMealTranslationDto>();

        var languages = new Dictionary<Language, string> {
            { Language.Es, regimen.EsNombre },
            { Language.En, regimen.EnNombre },
            { Language.Fr, regimen.FrNombre },
            { Language.De, regimen.DeNombre},
            { Language.Pt, regimen.PtNombre }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new StaticMealTranslationDto {
                    Name = language.Value,
                    LanguageIsoCode = language.Key.GetIsoCode()
                });
            }
        }

        return translations;
    }
}
