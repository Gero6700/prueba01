namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Helpers;
public static class LanguageHelper {
    public static string GetIsoCode(this Language language) {
        switch (language) {
            case Language.Es:
                return "ES";
            case Language.En:
                return "GB";
            case Language.Fr:
                return "FR";
            case Language.De:
                return "DE";
            case Language.Pt:
                return "PT";
            default:
                return "GB";
        }
    }
}
