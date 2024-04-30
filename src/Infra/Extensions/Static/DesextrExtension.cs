namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class DesextrExtension{
    public static ExtraTranslation ToExtraTranslation(this Desextr desextr) {
        return new ExtraTranslation {
            ExtraCode = desextr.ExtraCode,
            Description = desextr.Detext,
            LanguageIsoCode = desextr.IdioIsoCode
        };
    }
}
