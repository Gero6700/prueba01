namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class DesextrExtension{
    public static StaticExtraTranslationDto ToExtraTranslation(this Desextr desextr) {
        return new StaticExtraTranslationDto {
            ExtraCode = desextr.ExtraCode,
            Description = desextr.Detext,
            LanguageIsoCode = desextr.IdioIsoCode
        };
    }
}
