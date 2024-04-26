namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class EstServiceExtension {
    public static Service ToService(this EstServicio estServicio) {
        return new Service {
            Code = estServicio.Id.ToString(),
            CategoryCode = estServicio.IdCategoria.ToString(),
            Translations = GetTranslations(estServicio)
        };
    }

    private static List<ServiceTranslation> GetTranslations(EstServicio estServicio) {
        var translations = new List<ServiceTranslation>();

        var languages = new Dictionary<string, string> {
            { Language.Es.GetIsoCode(), estServicio.EsServicio },
            { Language.En.GetIsoCode(), estServicio.EnServicio },
            { Language.Fr.GetIsoCode(), estServicio.FrServicio },
            { Language.De.GetIsoCode(), estServicio.DeServicio },
            { Language.Pt.GetIsoCode(), estServicio.PtServicio }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new ServiceTranslation {
                    Name = language.Value,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }
}
