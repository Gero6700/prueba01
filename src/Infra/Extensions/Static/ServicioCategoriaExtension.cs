namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class ServicioCategoriaExtension {
    public static StaticServiceCategoryDto ToServiceCategoryDto(this ServicioCategoria servicioCategoria) {
        var serviceCategory = new StaticServiceCategoryDto {
            Code = servicioCategoria.Id.ToString(),
            ServiceCategoryTranslations = GetTranslations(servicioCategoria)
        };
        return serviceCategory;
    }

    private static List<StaticServiceCategoryTranslationDto> GetTranslations(ServicioCategoria servicioCategoria) {
        var translations = new List<StaticServiceCategoryTranslationDto>();

        var languages = new Dictionary<Language, string> {
            { Language.Es, servicioCategoria.EsNombre },
            { Language.En, servicioCategoria.EnNombre },
            { Language.Fr, servicioCategoria.FrNombre },
            { Language.De, servicioCategoria.DeNombre },
            { Language.Pt, servicioCategoria.PtNombre }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new StaticServiceCategoryTranslationDto {
                    Name = language.Value,
                    LanguageIsoCode = language.Key.GetIsoCode()
                });
            }
        }

        return translations;
    }
}
