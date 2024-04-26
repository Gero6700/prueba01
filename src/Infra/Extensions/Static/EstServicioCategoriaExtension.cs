namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class EstServicioCategoriaExtension {
    public static ServiceCategory ToServiceCategory(this EstServicioCategoria estServicioCategoria) {
        var serviceCategory = new ServiceCategory {
            Code = estServicioCategoria.Id.ToString(),
            Translations = GetTranslations(estServicioCategoria)
        };
        return serviceCategory;
    }

    private static List<Translation> GetTranslations(EstServicioCategoria estServicioCategoria) {
        var translations = new List<Translation>();

        var languages = new Dictionary<string, string> {
            { Language.Es.GetIsoCode(), estServicioCategoria.EsNombre },
            { Language.En.GetIsoCode(), estServicioCategoria.EnNombre },
            { Language.Fr.GetIsoCode(), estServicioCategoria.FrNombre },
            { Language.De.GetIsoCode(), estServicioCategoria.DeNombre },
            { Language.Pt.GetIsoCode(), estServicioCategoria.PtNombre }
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
