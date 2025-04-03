namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class SalonExtension {
    public static IEnumerable<StaticSalonDto>? ToSalonDto(this IEnumerable<Salon> salones, 
        IEnumerable<Imagen> imagenes) {
        if (!salones.Any()) {
            return null;
        }
        return salones.Select(salon => new StaticSalonDto {
            Code = salon.Id.ToString(),
            Name = salon.EsNombre,
            Surface = salon.Superficie,
            Width = salon.Ancho,
            Height = salon.Altura,
            Large = salon.Largo,
            BaseCapacity = null, //no tenemos datos
            BanquetCapacity = salon.AforoBanquete,
            CocktailCapacity = salon.AforoCocktail,
            ImperialCapacity = salon.AforoImperial,
            UCapacity = salon.AforoU,
            ClassroomCapacity = salon.AforoAula,
            SalonTranslations = GetTranslations(salon),
            SalonImages = imagenes.Any() ?
                imagenes.Where(i => i.UidPadre == salon.Uid).ToList().ToImageDto<StaticSalonImageDto>() :
                null
        }).ToList();
    }

    private static List<StaticSalonTranslationDto> GetTranslations(Salon salon) {
        var translations = new List<StaticSalonTranslationDto>();
        var descriptions = new Dictionary<Language, string> {
            { Language.Es, salon.EsDescripcion },
            { Language.En, salon.EnDescripcion },
            { Language.Fr, salon.FrDescripcion },
            { Language.De, salon.DeDescripcion },
            { Language.Pt, salon.PtDescripcion }
        };
        foreach (var language in Enum.GetValues<Language>()) {
            if (!descriptions.TryGetValue(language, out var description)) {
                continue;
            }
            if (string.IsNullOrEmpty(description)) {
                continue;
            }
            translations.Add(new StaticSalonTranslationDto {
                Description = description,
                LanguageIsoCode = language.GetIsoCode()
            });
        }
        return translations;
    }
}
