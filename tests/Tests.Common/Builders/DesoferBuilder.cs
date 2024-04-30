namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class DesoferBuilder {
    private DesoferRaw raw = null!;

    public static DesoferBuilder ADesoferBuilder() {
        return new DesoferBuilder {
            raw = GenerateRaw()
        };
    }

    public DesoferBuilder WithConofegeCode(string conofegeCode) {
        raw.ConofegeCode = conofegeCode;
        return this;
    }

    public DesoferBuilder WithDotext(string dotext) {
        raw.Dotext = dotext;
        return this;
    }

    public DesoferBuilder WithIdioIsoCode(string idioIsoCode) {
        raw.IdioIsoCode = idioIsoCode;
        return this;
    }

    public Desofer Build() {
        return new Faker<Desofer>()
            .RuleFor(x => x.ConofegeCode, raw.ConofegeCode)
            .RuleFor(x => x.Dotext, raw.Dotext)
            .RuleFor(x => x.IdioIsoCode, raw.IdioIsoCode)
            .Generate();
    }

    private static DesoferRaw GenerateRaw() {
        return new Faker<DesoferRaw>()
            .RuleFor(x => x.ConofegeCode, f => f.Random.String(5, 'A', 'Z'))
            .RuleFor(x => x.Dotext, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.IdioIsoCode, f => f.Random.ArrayElement(Enum.GetValues(typeof(Language)).Cast<Language>().Select(x => x.GetIsoCode()).ToArray()))
            .Generate();
    }

    private class DesoferRaw {
        public string ConofegeCode { get; set; } = string.Empty;
        public string Dotext { get; set; } = string.Empty;
        public string IdioIsoCode { get; set; } = string.Empty;
    }
}
