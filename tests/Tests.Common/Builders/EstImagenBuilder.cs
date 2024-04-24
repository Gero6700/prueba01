namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class EstImagenBuilder {
    private EstImagenRaw raw = null!;

    public static EstImagenBuilder AnEstImagenBuilder() {
        return new EstImagenBuilder {
            raw = GenerateRaw()
        };
    }

    public EstImagenBuilder WithPrioridad(int newPrioridad) {
        raw.Prioridad = newPrioridad;
        return this;
    }

    public EstImagenBuilder WithUrl(string newUrl) {
        raw.Url = newUrl;
        return this;
    }

    public EstImagenBuilder WithEsTitulo(string newEsTitulo) {
        raw.EsTitulo = newEsTitulo;
        return this;
    }

    public EstImagenBuilder WithEnTitulo(string newEnTitulo) {
        raw.EnTitulo = newEnTitulo;
        return this;
    }

    public EstImagenBuilder WithFrTitulo(string newFrTitulo) {
        raw.FrTitulo = newFrTitulo;
        return this;
    }

    public EstImagenBuilder WithDeTitulo(string newDeTitulo) {
        raw.DeTitulo = newDeTitulo;
        return this;
    }

    public EstImagenBuilder WithPtTitulo(string newPtTitulo) {
        raw.PtTitulo = newPtTitulo;
        return this;
    }

    public EstImagenBuilder WithEsDescripcion(string newEsDescripcion) {
        raw.EsDescripcion = newEsDescripcion;
        return this;
    }

    public EstImagenBuilder WithEnDescripcion(string newEnDescripcion) {
        raw.EnDescripcion = newEnDescripcion;
        return this;
    }

    public EstImagenBuilder WithFrDescripcion(string newFrDescripcion) {
        raw.FrDescripcion = newFrDescripcion;
        return this;
    }

    public EstImagenBuilder WithDeDescripcion(string newDeDescripcion) {
        raw.DeDescripcion = newDeDescripcion;
        return this;
    }

    public EstImagenBuilder WithPtDescripcion(string newPtDescripcion) {
        raw.PtDescripcion = newPtDescripcion;
        return this;
    }

    public EstImagen Build() {
       return new Faker<EstImagen>()
            .RuleFor(x => x.Prioridad, raw.Prioridad)
            .RuleFor(x => x.Url, raw.Url)
            .RuleFor(x => x.EsTitulo, raw.EsTitulo)
            .RuleFor(x => x.EnTitulo, raw.EnTitulo)
            .RuleFor(x => x.FrTitulo, raw.FrTitulo)
            .RuleFor(x => x.DeTitulo, raw.DeTitulo)
            .RuleFor(x => x.PtTitulo, raw.PtTitulo)
            .RuleFor(x => x.EsDescripcion, raw.EsDescripcion)
            .RuleFor(x => x.EnDescripcion, raw.EnDescripcion)
            .RuleFor(x => x.FrDescripcion, raw.FrDescripcion)
            .RuleFor(x => x.DeDescripcion, raw.DeDescripcion)
            .RuleFor(x => x.PtDescripcion, raw.PtDescripcion)
            .Generate();
    }

    private static EstImagenRaw GenerateRaw() {
        return new Faker<EstImagenRaw>()
            .RuleFor(x => x.Prioridad, f => f.Random.Number(1, 99999))
            .RuleFor(x => x.Url, f => f.Internet.Url())
            .RuleFor(x => x.EsTitulo, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EnTitulo, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.FrTitulo, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.DeTitulo, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.PtTitulo, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EsDescripcion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.EnDescripcion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.FrDescripcion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.DeDescripcion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.PtDescripcion, f => f.Lorem.Sentence(5))
            .Generate();
    }

    private class EstImagenRaw {
        public int Prioridad { get; set; }
        public string Url { get; set; } = string.Empty;
        public string EsTitulo { get; set; } = string.Empty;
        public string EnTitulo { get; set; } = string.Empty;
        public string FrTitulo { get; set; } = string.Empty;
        public string DeTitulo { get; set; } = string.Empty;
        public string PtTitulo { get; set; } = string.Empty;
        public string EsDescripcion { get; set; } = string.Empty;
        public string EnDescripcion { get; set; } = string.Empty;
        public string FrDescripcion { get; set; } = string.Empty;
        public string DeDescripcion { get; set; } = string.Empty;
        public string PtDescripcion { get; set; } = string.Empty;
    }
}
