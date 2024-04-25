namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class EstServicioCategoriaBuilder {
    private EstServicioCategoriaRaw raw = null!;

    public static EstServicioCategoriaBuilder AnEstServicioCategoriaBuilder() {
        return new EstServicioCategoriaBuilder {
            raw = GenerateRaw()
        };
    }

    public EstServicioCategoriaBuilder WithId(int id) {
        raw.Id = id;
        return this;
    }

    public EstServicioCategoriaBuilder WithEsNombre(string esNombre) {
        raw.EsNombre = esNombre;
        return this;
    }

    public EstServicioCategoriaBuilder WithEnNombre(string enNombre) {
        raw.EnNombre = enNombre;
        return this;
    }

    public EstServicioCategoriaBuilder WithFrNombre(string frNombre) {
        raw.FrNombre = frNombre;
        return this;
    }

    public EstServicioCategoriaBuilder WithDeNombre(string deNombre) {
        raw.DeNombre = deNombre;
        return this;
    }

    public EstServicioCategoriaBuilder WithPtNombre(string ptNombre) {
        raw.PtNombre = ptNombre;
        return this;
    }

    public EstServicioCategoria Build() {
        return new Faker<EstServicioCategoria>()
            .RuleFor(x => x.Id, raw.Id)
            .RuleFor(x => x.EsNombre, raw.EsNombre)
            .RuleFor(x => x.EnNombre, raw.EnNombre)
            .RuleFor(x => x.FrNombre, raw.FrNombre)
            .RuleFor(x => x.DeNombre, raw.DeNombre)
            .RuleFor(x => x.PtNombre, raw.PtNombre)
            .Generate();
    }
    private static EstServicioCategoriaRaw GenerateRaw() {
        return new Faker<EstServicioCategoriaRaw>()
            .RuleFor(x => x.Id, f => f.Random.Number())
            .RuleFor(x => x.EsNombre, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EnNombre, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.FrNombre, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.DeNombre, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.PtNombre, f => f.Lorem.Sentence(5))
            .Generate();
    }

    private class EstServicioCategoriaRaw {
        public int Id { get; set; }
        public string EsNombre { get; set; } = string.Empty;
        public string EnNombre { get; set; } = string.Empty;
        public string FrNombre { get; set; } = string.Empty;
        public string DeNombre { get; set; } = string.Empty;
        public string PtNombre { get; set; } = string.Empty;
    }
}
