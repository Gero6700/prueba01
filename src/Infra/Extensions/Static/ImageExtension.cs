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
    //public static IEnumerable<StaticRoomImageDto>? ToRoomImageDto(this IEnumerable<Imagen> imagenes) {
    //    if (!imagenes.Any()) {
    //        return null;
    //    }

    //    return imagenes.Select(imagen => new StaticRoomImageDto {
    //        Order = imagen.Prioridad,
    //        Url = $"http://servicios.playasenator.com/imagen.aspx?id={imagen.Url}",
    //        RoomImageTranslations = GetTranslations<StaticRoomImageTranslationDto>(imagen)
    //    }).ToList();
    //}

    //public static IEnumerable<StaticHotelImageDto>? ToHotelImageDto(this IEnumerable<Imagen> imagenes) {
    //    if (!imagenes.Any()) {
    //        return null;
    //    }
    //    return imagenes.Select(imagen => new StaticHotelImageDto {
    //        Order = imagen.Prioridad,
    //        Url = $"http://servicios.playasenator.com/imagen.aspx?id={imagen.Url}",
    //        HotelImageTranslations = GetTranslations<StaticHotelImageTranslationDto>(imagen)
    //    }).ToList();
    //}

    //public static IEnumerable<StaticSwimmingPoolImageDto>? ToSwimmingPoolImageDto(this IEnumerable<Imagen> imagenes) {
    //    if (!imagenes.Any()) {
    //        return null;
    //    }
    //    return imagenes.Select(imagen => new StaticSwimmingPoolImageDto {
    //        Order = imagen.Prioridad,
    //        Url = $"http://servicios.playasenator.com/imagen.aspx?id={imagen.Url}",
    //        SwimmingPoolImageTranslations = GetTranslations<StaticSwimmingPoolImageTranslationDto>(imagen)
    //    }).ToList();
    //}

    //public static IEnumerable<StaticSalonImageDto>? ToSalonImageDto(this IEnumerable<Imagen> imagenes) {
    //    if (!imagenes.Any()) {
    //        return null;
    //    }
    //    return imagenes.Select(imagen => new StaticSalonImageDto {
    //        Order = imagen.Prioridad,
    //        Url = $"http://servicios.playasenator.com/imagen.aspx?id={imagen.Url}",
    //        SalonImageTranslations = GetTranslations<StaticSalonImageTranslationDto>(imagen)
    //    }).ToList();
    //}

    //private static List<StaticImageTranslationDto> GetTranslations(Imagen imagen) {
    //    var translations = new List<StaticImageTranslationDto>();
    //    var titleDescriptions = new Dictionary<Language, string> {
    //        { Language.Es, imagen.EsTitulo },
    //        { Language.En, imagen.EnTitulo },
    //        { Language.Fr, imagen.FrTitulo },
    //        { Language.De, imagen.DeTitulo },
    //        { Language.Pt, imagen.PtTitulo }
    //    };
    //    var descriptions = new Dictionary<Language, string> {
    //        { Language.Es, imagen.EsDescripcion },
    //        { Language.En, imagen.EnDescripcion },
    //        { Language.Fr, imagen.FrDescripcion },
    //        { Language.De, imagen.DeDescripcion },
    //        { Language.Pt, imagen.PtDescripcion }
    //    };
    //    foreach (var language in Enum.GetValues<Language>()) {
    //        if (!titleDescriptions.TryGetValue(language, out var title) ||
    //            !descriptions.TryGetValue(language, out var description)) {
    //            continue;
    //        }
    //        if (string.IsNullOrEmpty(title)) {
    //            continue;
    //        }
    //        translations.Add(new T {
    //            LanguageIsoCode = language.GetIsoCode(),
    //            Title = title,
    //            Description = description
    //        });
    //    }
    //    return translations;
    //}



    private static List<StaticImageTranslationDto> GetTranslations(Imagen imagen) {
        var translations = new List<StaticImageTranslationDto>();
        var titleDescriptions = new Dictionary<Language, string> {
            { Language.Es, imagen.EsTitulo },
            { Language.En, imagen.EnTitulo },
            { Language.Fr, imagen.FrTitulo },
            { Language.De, imagen.DeTitulo },
            { Language.Pt, imagen.PtTitulo }
        };
        var descriptions = new Dictionary<Language, string> {
            { Language.Es, imagen.EsDescripcion },
            { Language.En, imagen.EnDescripcion },
            { Language.Fr, imagen.FrDescripcion },
            { Language.De, imagen.DeDescripcion },
            { Language.Pt, imagen.PtDescripcion }
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
