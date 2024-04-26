namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class EstServicioBuilder {
    private EstServicioRaw raw = null!;

    public static EstServicioBuilder AnEstServicioBuilder() {
        return new EstServicioBuilder {
            raw = GenerateRaw()
        };
    }

    public EstServicioBuilder WithId(int id) {
        raw.Id = id;
        return this;
    }

    public EstServicioBuilder WithIdCategoria(int idCategoria) {
        raw.IdCategoria = idCategoria;
        return this;
    }

    public EstServicioBuilder WithEsServicio(string esServicio) {
        raw.EsServicio = esServicio;
        return this;
    }

    public EstServicioBuilder WithEnServicio(string enServicio) {
        raw.EnServicio = enServicio;
        return this;
    }

    public EstServicioBuilder WithDeServicio(string deServicio) {
        raw.DeServicio = deServicio;
        return this;
    }

    public EstServicioBuilder WithFrServicio(string frServicio) {
        raw.FrServicio = frServicio;
        return this;
    }

    public EstServicioBuilder WithPtServicio(string ptServicio) {
        raw.PtServicio = ptServicio;
        return this;
    }

    public EstServicio Build() {
        return new Faker<EstServicio>()
            .RuleFor(x => x.Id, raw.Id)
            .RuleFor(x => x.IdCategoria, raw.IdCategoria)
            .RuleFor(x => x.EsServicio, raw.EsServicio)
            .RuleFor(x => x.EnServicio, raw.EnServicio)
            .RuleFor(x => x.DeServicio, raw.DeServicio)
            .RuleFor(x => x.FrServicio, raw.FrServicio)
            .RuleFor(x => x.PtServicio, raw.PtServicio)
            .Generate();
    }

    private static EstServicioRaw GenerateRaw() {
        return new Faker<EstServicioRaw>()
            .RuleFor(x => x.Id, f => f.Random.Number(1,99))
            .RuleFor(x => x.IdCategoria, f => f.Random.Number(1,99))
            .RuleFor(x => x.EsServicio, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EnServicio, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.DeServicio, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.FrServicio, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.PtServicio, f => f.Lorem.Sentence(2))
            .Generate();
    }

    private class EstServicioRaw {
        public int Id { get; set; }
        public int IdCategoria { get; set; }
        public string EsServicio { get; set; } = string.Empty;
        public string EnServicio { get; set; } = string.Empty;
        public string DeServicio { get; set; } = string.Empty;
        public string FrServicio { get; set; } = string.Empty;
        public string PtServicio { get; set; } = string.Empty;
    }
}
