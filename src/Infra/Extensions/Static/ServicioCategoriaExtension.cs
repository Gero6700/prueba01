namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class ServicioCategoriaExtension {
    public static IEnumerable<StaticServiceCategoryDto>? ToServiceCategoryDto(this IEnumerable<ServicioCategoria> servicioCategorias) {
        if(!servicioCategorias.Any()) {
            return null;
        }
        return servicioCategorias.Select(servicioCategoria => new StaticServiceCategoryDto {
            Code = servicioCategoria.Id.ToString(),
            ServiceCategoryTranslations = GetTranslations(servicioCategoria)
        }).ToList();
    }

    private static List<StaticServiceCategoryTranslationDto>? GetTranslations(ServicioCategoria servicioCategoria) {
        var translations = new List<StaticServiceCategoryTranslationDto>();

        var languages = new Dictionary<Language, string> {
            { Language.Es, servicioCategoria.EsNombre ?? string.Empty },
            { Language.En, servicioCategoria.EnNombre ?? string.Empty },
            { Language.Fr, servicioCategoria.FrNombre ?? string.Empty },
            { Language.De, servicioCategoria.DeNombre ?? string.Empty },
            { Language.Pt, servicioCategoria.PtNombre ?? string.Empty }
        };

        foreach (var language in languages) {
            if (!string.IsNullOrEmpty(language.Value)) {
                translations.Add(new StaticServiceCategoryTranslationDto {
                    Name = language.Value,
                    LanguageIsoCode = language.Key.GetIsoCode()
                });
            }
        }

        return translations.Count == 0 ? null : translations;
    }
}
