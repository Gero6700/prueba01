namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class DesextrBuilder {
    private DesextrRaw raw=null!;

    public static DesextrBuilder ADesextrBuilder() {
        return new DesextrBuilder {
            raw = GenerateRaw()
        };
    }   

    public DesextrBuilder WithExtraCode(string extraCode) {
        raw.ExtraCode = extraCode;
        return this;
    }

    public DesextrBuilder WithDetext(string detext) {
        raw.Detext = detext;
        return this;
    }

    public DesextrBuilder WithIdioIsoCode(string idioIsoCode) {
        raw.IdioIsoCode = idioIsoCode;
        return this;
    }

    public Desextr Build() {
        return new Faker<Desextr>()
            .RuleFor(x => x.ExtraCode, raw.ExtraCode)
            .RuleFor(x => x.Detext, raw.Detext)
            .RuleFor(x => x.IdioIsoCode, raw.IdioIsoCode)
            .Generate();
    }

    private static DesextrRaw GenerateRaw() {
        return new Faker<DesextrRaw>()
            .RuleFor(x => x.ExtraCode, f => f.Random.String(5, 'A', 'Z'))
            .RuleFor(x => x.Detext, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.IdioIsoCode, f => f.Random.ArrayElement(Enum.GetValues(typeof(Language)).Cast<Language>().Select(x => x.GetIsoCode()).ToArray()))
            .Generate();
    }

    private class DesextrRaw {
        public string ExtraCode { get; set; } = string.Empty;
        public string Detext { get; set; } = string.Empty;
        public string IdioIsoCode { get; set; } = string.Empty;
    }
}
