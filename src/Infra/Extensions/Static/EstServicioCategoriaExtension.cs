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
            { "es-ES", estServicioCategoria.EsNombre },
            { "en-GB", estServicioCategoria.EnNombre },
            { "fr-FR", estServicioCategoria.FrNombre },
            { "de-DE", estServicioCategoria.DeNombre },
            { "pt-PT", estServicioCategoria.PtNombre }
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
