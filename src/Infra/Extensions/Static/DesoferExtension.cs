namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class DesoferExtension{
    public static OfferAndSupplementTranslation ToOfferAndSupplementTranslation(this Desofer desofer) {
        return new OfferAndSupplementTranslation {
            OfferAndSupplementCode = desofer.ConofegeCode,
            Description = desofer.Dotext,
            LanguageIsoCode = desofer.IdioIsoCode
        };
    }
}
