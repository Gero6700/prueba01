using Senator.As400.Cloud.Sync.Infrastructure.Domain.Entities;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class EstRegimenExtension {
    public static StaticMealDto ToRegime(this Regimen estRegimen) {
        return new StaticMealDto {
            Code = estRegimen.Codigo,
            MealTranslations = GetTranslations(estRegimen)
        };
    }

    private static List<StaticMealTranslationDto> GetTranslations(Regimen regimen) {
        var translations = new List<StaticMealTranslationDto>();

        var languages = new Dictionary<string, string> {
            { Language.Es.GetIsoCode(), regimen.EsNombre },
            { Language.En.GetIsoCode(), regimen.EnNombre },
            { Language.Fr.GetIsoCode(), regimen.FrNombre },
            { Language.De.GetIsoCode(), regimen.DeNombre},
            { Language.Pt.GetIsoCode(), regimen.PtNombre }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new StaticMealTranslationDto {
                    Name = language.Value,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }
}
