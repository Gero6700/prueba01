namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class ImageExtension {
    public static IEnumerable<T>? ToImageDto<T>(this IEnumerable<Imagen> imagenes) where T : IImageDto, new() {
        if (!imagenes.Any()) {
            return null;
        }
        return imagenes.Select(imagen => new T {
            Order = imagen.Prioridad,
            Url = $"http://servicios.playasenator.com/imagen.aspx?id={imagen.Url}",
            ImageTranslations = GetTranslations(imagen)
        }).ToList();
    }
   
    private static List<StaticImageTranslationDto> GetTranslations(Imagen imagen) {
        var translations = new List<StaticImageTranslationDto>();
        var titleDescriptions = new Dictionary<Language, string> {
            { Language.Es, imagen.EsTitulo.Trim() },
            { Language.En, imagen.EnTitulo.Trim() },
            { Language.Fr, imagen.FrTitulo.Trim() },
            { Language.De, imagen.DeTitulo.Trim() },
            { Language.Pt, imagen.PtTitulo.Trim() }
        };
        var descriptions = new Dictionary<Language, string> {
            { Language.Es, imagen.EsDescripcion.Trim() },
            { Language.En, imagen.EnDescripcion.Trim() },
            { Language.Fr, imagen.FrDescripcion.Trim() },
            { Language.De, imagen.DeDescripcion.Trim() },
            { Language.Pt, imagen.PtDescripcion.Trim() }
        };
        foreach (var language in Enum.GetValues<Language>()) {
            if (!titleDescriptions.TryGetValue(language, out var title) ||
                !descriptions.TryGetValue(language, out var description)) {
                continue;
            }
            if (string.IsNullOrEmpty(title)) {
                continue;
            }
            translations.Add(new StaticImageTranslationDto {
                LanguageIsoCode = language.GetIsoCode(),
                Title = title,
                Description = string.IsNullOrEmpty(description) ? null : description
            });
        }
        return translations;
    }
}
