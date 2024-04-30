namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class EstRegimenExtension {
    public static Dtos.BookingCenter.Static.Regime ToRegime(this EstRegimen estRegimen) {
        return new Dtos.BookingCenter.Static.Regime
        {
            Code = estRegimen.Regimen,
            Translations = GetTranslations(estRegimen)
        };
    }

    private static List<Translation> GetTranslations(EstRegimen regimen) {
        var translations = new List<Translation>();

        var languages = new Dictionary<string, string> {
            { Language.Es.GetIsoCode(), regimen.EsNombre },
            { Language.En.GetIsoCode(), regimen.EnNombre },
            { Language.Fr.GetIsoCode(), regimen.FrNombre },
            { Language.De.GetIsoCode(), regimen.DeNombre},
            { Language.Pt.GetIsoCode(), regimen.PtNombre }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new Translation {
                    Name = language.Value,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }
}
