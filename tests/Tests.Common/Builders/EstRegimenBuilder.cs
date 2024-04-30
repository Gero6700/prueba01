namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class EstRegimenBuilder {
    private EstRegimenRaw raw = null!;

    public static EstRegimenBuilder AnEstRegimenBuilder() {
        return new EstRegimenBuilder {
            raw = GenerateRaw()
        };
    }

    public EstRegimenBuilder WithRegimen(string regimen) {
        raw.Regimen = regimen;
        return this;
    }

    public EstRegimenBuilder WithEsNombre(string esNombre) {
        raw.EsNombre = esNombre;
        return this;
    }

    public EstRegimenBuilder WithEnNombre(string enNombre) {
        raw.EnNombre = enNombre;
        return this;
    }

    public EstRegimenBuilder WithFrNombre(string frNombre) {
        raw.FrNombre = frNombre;
        return this;
    }

    public EstRegimenBuilder WithDeNombre(string deNombre) {
        raw.DeNombre = deNombre;
        return this;
    }

    public EstRegimenBuilder WithPtNombre(string ptNombre) {
        raw.PtNombre = ptNombre;
        return this;
    }

    public EstRegimen Build() {
        return new Faker<EstRegimen>()
            .RuleFor(x => x.Regimen, raw.Regimen)
            .RuleFor(x => x.EsNombre, raw.EsNombre)
            .RuleFor(x => x.EnNombre, raw.EnNombre)
            .RuleFor(x => x.FrNombre, raw.FrNombre)
            .RuleFor(x => x.DeNombre, raw.DeNombre)
            .RuleFor(x => x.PtNombre, raw.PtNombre)
            .Generate();
    }

    private static EstRegimenRaw GenerateRaw() {
        return new Faker<EstRegimenRaw>()
            .RuleFor(x => x.Regimen, f => f.Random.String(2, 'A', 'Z'))
            .RuleFor(x => x.EsNombre, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EnNombre, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.FrNombre, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.DeNombre, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.PtNombre, f => f.Lorem.Sentence(2))
            .Generate();
    }

    private class EstRegimenRaw {
        public string Regimen { get; set; } = string.Empty;
        public string EsNombre { get; set; } = string.Empty;
        public string EnNombre { get; set; } = string.Empty;
        public string FrNombre { get; set; } = string.Empty;
        public string DeNombre { get; set; } = string.Empty;
        public string PtNombre { get; set; } = string.Empty;
    }
}
