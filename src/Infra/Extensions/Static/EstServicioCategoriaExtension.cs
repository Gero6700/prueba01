namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class EstServicioCategoriaExtension {
    public static StaticServiceCategoryDto ToServiceCategory(this ServicioCategoria estServicioCategoria) {
        var serviceCategory = new StaticServiceCategoryDto {
            Code = estServicioCategoria.Id.ToString(),
            ServiceCategoryTranslations = GetTranslations(estServicioCategoria)
        };
        return serviceCategory;
    }

    private static List<StaticServiceCategoryTranslationDto> GetTranslations(ServicioCategoria estServicioCategoria) {
        var translations = new List<StaticServiceCategoryTranslationDto>();

        var languages = new Dictionary<string, string> {
            { Language.Es.GetIsoCode(), estServicioCategoria.EsNombre },
            { Language.En.GetIsoCode(), estServicioCategoria.EnNombre },
            { Language.Fr.GetIsoCode(), estServicioCategoria.FrNombre },
            { Language.De.GetIsoCode(), estServicioCategoria.DeNombre },
            { Language.Pt.GetIsoCode(), estServicioCategoria.PtNombre }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new StaticServiceCategoryTranslationDto {
                    Name = language.Value,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }
}
