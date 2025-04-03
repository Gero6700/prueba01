namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class ServiceExtension
{
    public static IEnumerable<StaticServiceDto>? ToServiceDto(this IEnumerable<Servicio> servicios){
        if (!servicios.Any()) {
            return null;
        }
        return servicios.Select(servicio => new StaticServiceDto {
            Code = servicio.Id.ToString(),
            ServiceCategory = new StaticServiceCategoryDto {
                Code = servicio.IdCategoria.ToString(),
                ServiceCategoryTranslations = GetCategoryTranslations(servicio)
            },
            ServiceTranslations = GetTranslations(servicio)
        }).ToList();

    }

    private static List<StaticServiceTranslationDto> GetTranslations(Servicio servicio)
    {
        var translations = new List<StaticServiceTranslationDto>();

        var names = new Dictionary<Language, string> {
            { Language.Es, servicio.EsServicio },
            { Language.En, servicio.EnServicio },
            { Language.Fr, servicio.FrServicio },
            { Language.De, servicio.DeServicio },
            { Language.Pt, servicio.PtServicio }
        };

        var descriptions = new Dictionary<Language, string> {
            { Language.Es, servicio.EsDetalle },
            { Language.En, servicio.EnDetalle },
            { Language.Fr, servicio.FrDetalle },
            { Language.De, servicio.DeDetalle },
            { Language.Pt, servicio.PtDetalle }
        };
      
        foreach(var language in Enum.GetValues<Language>()) {
            if (!names.TryGetValue(language, out var name) || 
                !descriptions.TryGetValue(language, out var description)) {
                continue;
            }
            if (string.IsNullOrEmpty(name)) {
                continue;
            }
            translations.Add(new StaticServiceTranslationDto {
                    Name = name,
                    Description = string.IsNullOrEmpty(description) ? null : description,
                    LanguageIsoCode = language.GetIsoCode()
            });
        }

        return translations;
    }

    private static List<StaticServiceCategoryTranslationDto> GetCategoryTranslations(Servicio estServicio) {
        var translations = new List<StaticServiceCategoryTranslationDto>();

        var languages = new Dictionary<Language, string> {
            { Language.Es, estServicio.EsNombreCategoria },
            { Language.En, estServicio.EnNombreCategoria },
            { Language.Fr, estServicio.FrNombreCategoria },
            { Language.De, estServicio.DeNombreCategoria },
            { Language.Pt, estServicio.PtNombreCategoria }
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
