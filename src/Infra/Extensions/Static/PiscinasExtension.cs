namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class PiscinasExtension {
    public static IEnumerable<StaticSwimmingPoolDto>? ToSwimmingPoolDto(this IEnumerable<Piscina> piscinas,
        IEnumerable<Imagen> imagenes) {
        if (!piscinas.Any()) {
            return null;
        }
        return piscinas.Select(piscina => new StaticSwimmingPoolDto {
            Code = piscina.Id.ToString(),
            PoolsNumber = piscina.Cantidad,
            Capacity = piscina.Aforo,
            Surface = piscina.Superficie,
            IsOpen = true, //no tenemos datos
            IsHeatedPool = false, //no tenemos datos
            HasWaterSlides = false, //no tenemos datos
            SwimmingPoolTranslations = GetTranslations(piscina),
            SwimmingPoolImages = imagenes.Any() ? 
                imagenes.Where(i => i.UidPadre == piscina.Uid).ToList().ToImageDto<StaticSwimmingPoolImageDto>() : 
                null
        }).ToList();
    }
    private static List<StaticSwimmingPoolTranslationDto> GetTranslations(Piscina piscina) {
        var translations = new List<StaticSwimmingPoolTranslationDto>();
        var names = new Dictionary<Language, string> {
            { Language.Es, piscina.EsPiscina },
            { Language.En, piscina.EnPiscina },
            { Language.Fr, piscina.FrPiscina },
            { Language.De, piscina.DePiscina },
            { Language.Pt, piscina.PtPiscina }
        };
        var descriptions = new Dictionary<Language, string> {
            { Language.Es, piscina.EsDetalles },
            { Language.En, piscina.EnDetalles },
            { Language.Fr, piscina.FrDetalles },
            { Language.De, piscina.DeDetalles },
            { Language.Pt, piscina.PtDetalles }
        };

        foreach (var language in Enum.GetValues<Language>()) {
            if (!names.TryGetValue(language, out var name) ||
                !descriptions.TryGetValue(language, out var description)) {
                continue;
            }
            if (string.IsNullOrEmpty(name)) {
                continue;
            }
            translations.Add(new StaticSwimmingPoolTranslationDto {
                Name = name,
                Description = string.IsNullOrEmpty(description) ? null : description,
                LanguageIsoCode = language.GetIsoCode()
            });
        }
        return translations;
    }
}
