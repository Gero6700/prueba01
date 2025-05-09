namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class ServiceExtension
{
    public static IEnumerable<StaticServiceDto>? ToServiceDto(this IEnumerable<Servicio> servicios){
        if (!servicios.Any()) {
            return null;
        }
        return servicios.Select(servicio => new StaticServiceDto {
            Code = servicio.Id.ToString(),
            ServiceCategoryCode = servicio.IdCategoria.ToString(),
            ServiceTranslations = GetTranslations(servicio)
        }).ToList();

    }

    public static IEnumerable<StaticEquipmentDto>? ToEquipmentDto(this IEnumerable<Servicio> servicios) {
        if (!servicios.Any()) {
            return null;
        }
        return servicios.Select(servicio => new StaticEquipmentDto {
            Code = servicio.Id.ToString(),
            Name = servicio.EsServicio?? string.Empty,
            EquipmentTranslations = GetEquipmentTranslations(servicio)
        }).ToList();
    }

    private static List<EquipmentTranslationDto>? GetEquipmentTranslations(Servicio servicio) {
        var translations = new List<EquipmentTranslationDto>();

        var names = new Dictionary<Language, string> {
            { Language.Es, servicio.EsServicio?? string.Empty },
            { Language.En, servicio.EnServicio?? string.Empty },
            { Language.Fr, servicio.FrServicio?? string.Empty },
            { Language.De, servicio.DeServicio?? string.Empty },
            { Language.Pt, servicio.PtServicio?? string.Empty }
        };

        foreach (var language in Enum.GetValues<Language>()) {
            if (!names.TryGetValue(language, out var name)) {
                continue;
            }
            if (string.IsNullOrEmpty(name)) {
                continue;
            }
            translations.Add(new EquipmentTranslationDto {
                Description = name,
                LanguageIsoCode = language.GetIsoCode()
            });
        }

        return translations.Count == 0 ? null : translations;
    }

    private static List<StaticServiceTranslationDto>? GetTranslations(Servicio servicio)
    {
        var translations = new List<StaticServiceTranslationDto>();

        var names = new Dictionary<Language, string> {
            { Language.Es, servicio.EsServicio?? string.Empty },
            { Language.En, servicio.EnServicio?? string.Empty },
            { Language.Fr, servicio.FrServicio?? string.Empty },
            { Language.De, servicio.DeServicio?? string.Empty },
            { Language.Pt, servicio.PtServicio?? string.Empty }
        };
      
        foreach(var language in Enum.GetValues<Language>()) {
            if (!names.TryGetValue(language, out var name)) {
                continue;
            }
            if (string.IsNullOrEmpty(name)) {
                continue;
            }
            translations.Add(new StaticServiceTranslationDto {
                    Name = name,
                    Description = null,
                    LanguageIsoCode = language.GetIsoCode()
            });
        }

        return translations.Count == 0 ? null : translations;
    }
}
