namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class EstCamaTipoBuilder{
    private EstCamaTipoRaw raw = null!;

    public static EstCamaTipoBuilder AnEstCamaTipoBuilder() {
        return new EstCamaTipoBuilder {
            raw = GenerateRaw()
        };
    }

    public EstCamaTipoBuilder WithAnchoCm(int newAnchoCm) {
        raw.AnchoCm = newAnchoCm;
        return this;
    }

    public EstCamaTipoBuilder WithAltoCm(int newAltoCm) {
        raw.AltoCm = newAltoCm;
        return this;
    }

    public EstCamaTipoBuilder WithEsNombre(string newEsNombre) {
        raw.EsNombre = newEsNombre;
        return this;
    }

    public EstCamaTipoBuilder WithEnNombre(string newEnNombre) {
        raw.EnNombre = newEnNombre;
        return this;
    }

    public EstCamaTipoBuilder WithFrNombre(string newFrNombre) {
        raw.FrNombre = newFrNombre;
        return this;
    }

    public EstCamaTipoBuilder WithDeNombre(string newDeNombre) {
        raw.DeNombre = newDeNombre;
        return this;
    }

    public EstCamaTipoBuilder WithPtNombre(string newPtNombre) {
        raw.PtNombre = newPtNombre;
        return this;
    }

    public EstCamaTipo Build() {
        return new Faker<EstCamaTipo>()
            .RuleFor(x => x.AnchoCm, f => raw.AnchoCm)
            .RuleFor(x => x.AltoCm, f => raw.AltoCm)
            .RuleFor(x => x.EsNombre, f => raw.EsNombre)
            .RuleFor(x => x.EnNombre, f => raw.EnNombre)
            .RuleFor(x => x.FrNombre, f => raw.FrNombre)
            .RuleFor(x => x.DeNombre, f => raw.DeNombre)
            .RuleFor(x => x.PtNombre, f => raw.PtNombre)
            .Generate();
    }

    private static EstCamaTipoRaw GenerateRaw() {
        return new Faker<EstCamaTipoRaw>()
            .RuleFor(x => x.AnchoCm, f => f.Random.Number(80, 200))
            .RuleFor(x => x.AltoCm, f => f.Random.Number(180, 200))
            .RuleFor(x => x.EsNombre, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EnNombre, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.FrNombre, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.DeNombre, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.PtNombre, f => f.Lorem.Sentence(2))
            .Generate();
    }

    private class EstCamaTipoRaw {
        public int AnchoCm { get; set; }
        public int AltoCm { get; set; }
        public string EsNombre { get; set; } = string.Empty;
        public string EnNombre { get; set; } = string.Empty;
        public string FrNombre { get; set; } = string.Empty;
        public string DeNombre { get; set; } = string.Empty;
        public string PtNombre { get; set; } = string.Empty;
    }
}
