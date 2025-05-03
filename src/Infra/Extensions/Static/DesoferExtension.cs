namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class DesoferExtension{
    public static StaticOfferAndSupplementTranslation ToOfferAndSupplementTranslation(this Desofer desofer) {
        return new StaticOfferAndSupplementTranslation {
            OfferAndSupplementCode = desofer.ConofegeCode,
            Description = desofer.Dotext,
            LanguageIsoCode = desofer.IdioIsoCode
        };
    }
}
