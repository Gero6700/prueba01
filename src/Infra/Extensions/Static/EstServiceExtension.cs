namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class EstServiceExtension
{
    public static StaticServiceDto ToService(this Servicio estServicio)
    {
        return new StaticServiceDto
        {
            Code = estServicio.Id.ToString(),
            ServiceCategory = estServicio.Categoria.ToServiceCategory(),
            ServiceTranslations = GetTranslations(estServicio)
        };
    }

    private static List<StaticServiceTranslationDto> GetTranslations(Servicio estServicio)
    {
        var translations = new List<StaticServiceTranslationDto>();

        var languages = new Dictionary<string, string> {
            { Language.Es.GetIsoCode(), estServicio.EsServicio },
            { Language.En.GetIsoCode(), estServicio.EnServicio },
            { Language.Fr.GetIsoCode(), estServicio.FrServicio },
            { Language.De.GetIsoCode(), estServicio.DeServicio },
            { Language.Pt.GetIsoCode(), estServicio.PtServicio }
        };

        foreach (var language in languages)
        {
            if (!string.IsNullOrEmpty(language.Value))
            {
                translations.Add(new StaticServiceTranslationDto
                {
                    Name = language.Value,
                    LanguageIsoCode = language.Key
                });
            }
        }

        return translations;
    }

    private static List<StaticServiceCategoryTranslationDto> GetCategoryTranslations(ServicioCategoria categoria)
    {
        // Implement this method based on your requirements
        return new List<StaticServiceCategoryTranslationDto>();
    }
}
