namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Helpers;
public static class LanguageHelper {
    public static string GetIsoCode(this Language language) {
        switch (language) {
            case Language.Es:
                return "es-ES";
            case Language.En:
                return "en-GB";
            case Language.Fr:
                return "fr-FR";
            case Language.De:
                return "de-DE";
            case Language.Pt:
                return "pt-PT";
            default:
                return "en-GB";
        }
    }
}
