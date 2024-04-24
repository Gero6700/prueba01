namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class EstPiscinaBuilder {
    private EstPiscinaRaw raw = null!;

    public static EstPiscinaBuilder AnEstPiscinaBuilder() {
        return new EstPiscinaBuilder {
            raw = GenerateRaw()
        };
    }

    public EstPiscinaBuilder WithId(int newId) {
        raw.Id = newId;
        return this;
    }

    public EstPiscinaBuilder WithCantidad(int newCantidad) {
        raw.Cantidad = newCantidad;
        return this;
    }

    public EstPiscinaBuilder WithAforo(int newAforo) {
        raw.Aforo = newAforo;
        return this;
    }

    public EstPiscinaBuilder WithSuperficie(decimal newSuperficie) {
        raw.Superficie = newSuperficie;
        return this;
    }

    public EstPiscinaBuilder WithEsPiscina(string newEsPiscina) {
        raw.EsPiscina = newEsPiscina;
        return this;
    }

    public EstPiscinaBuilder WithEnPiscina(string newEnPiscina) {
        raw.EnPiscina = newEnPiscina;
        return this;
    }

    public EstPiscinaBuilder WithFrPiscina(string newFrPiscina) {
        raw.FrPiscina = newFrPiscina;
        return this;
    }

    public EstPiscinaBuilder WithDePiscina(string newDePiscina) {
        raw.DePiscina = newDePiscina;
        return this;
    }

    public EstPiscinaBuilder WithPtPiscina(string newPtPiscina) {
        raw.PtPiscina = newPtPiscina;
        return this;
    }

    public EstPiscinaBuilder WithEsDetalles(string newEsDetalles) {
        raw.EsDetalles = newEsDetalles;
        return this;
    }

    public EstPiscinaBuilder WithEnDetalles(string newEnDetalles) {
        raw.EnDetalles = newEnDetalles;
        return this;
    }

    public EstPiscinaBuilder WithFrDetalles(string newFrDetalles) {
        raw.FrDetalles = newFrDetalles;
        return this;
    }

    public EstPiscinaBuilder WithDeDetalles(string newDeDetalles) {
        raw.DeDetalles = newDeDetalles;
        return this;
    }

    public EstPiscinaBuilder WithPtDetalles(string newPtDetalles) {
        raw.PtDetalles = newPtDetalles;
        return this;
    }

    public EstPiscinaBuilder WithImagenes(List<EstImagenBuilder> newImagenes) {
        raw.Imagenes = newImagenes;
        return this;
    }

    public EstPiscina Build() {
        return new Faker<EstPiscina>()
            .RuleFor(x => x.Id, raw.Id)
            .RuleFor(x => x.Cantidad, raw.Cantidad)
            .RuleFor(x => x.Aforo, raw.Aforo)
            .RuleFor(x => x.Superficie, raw.Superficie)
            .RuleFor(x => x.EsPiscina, raw.EsPiscina)
            .RuleFor(x => x.EnPiscina, raw.EnPiscina)
            .RuleFor(x => x.FrPiscina, raw.FrPiscina)
            .RuleFor(x => x.DePiscina, raw.DePiscina)
            .RuleFor(x => x.PtPiscina, raw.PtPiscina)
            .RuleFor(x => x.EsDetalles, raw.EsDetalles)
            .RuleFor(x => x.EnDetalles, raw.EnDetalles)
            .RuleFor(x => x.FrDetalles, raw.FrDetalles)
            .RuleFor(x => x.DeDetalles, raw.DeDetalles)
            .RuleFor(x => x.PtDetalles, raw.PtDetalles)
            .RuleFor(x => x.Imagenes, raw.Imagenes.Select(x => x.Build()).ToList())
            .Generate();
    }

    private static EstPiscinaRaw GenerateRaw() {
        return new Faker<EstPiscinaRaw>()
            .RuleFor(x => x.Id, f => f.Random.Number())
            .RuleFor(x => x.Cantidad, f => f.Random.Number(0, 3))
            .RuleFor(x => x.Aforo, f => f.Random.Number(1, 99))
            .RuleFor(x => x.Superficie, f => f.Random.Decimal())
            .RuleFor(x => x.EsPiscina, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EnPiscina, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.FrPiscina, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.DePiscina, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.PtPiscina, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EsDetalles, f => f.Lorem.Sentence())
            .RuleFor(x => x.EnDetalles, f => f.Lorem.Sentence())
            .RuleFor(x => x.FrDetalles, f => f.Lorem.Sentence())
            .RuleFor(x => x.DeDetalles, f => f.Lorem.Sentence())
            .RuleFor(x => x.PtDetalles, f => f.Lorem.Sentence())
            .RuleFor(x => x.Imagenes, new List<EstImagenBuilder> { EstImagenBuilder.AnEstImagenBuilder() })
            .Generate();
    }

    private class EstPiscinaRaw {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Aforo { get; set; }
        public decimal Superficie { get; set; }
        public string EsPiscina { get; set; } = string.Empty;
        public string EnPiscina { get; set; } = string.Empty;
        public string FrPiscina { get; set; } = string.Empty;
        public string DePiscina { get; set; } = string.Empty;
        public string PtPiscina { get; set; } = string.Empty;
        public string EsDetalles { get; set; } = string.Empty;
        public string EnDetalles { get; set; } = string.Empty;
        public string FrDetalles { get; set; } = string.Empty;
        public string DeDetalles { get; set; } = string.Empty;
        public string PtDetalles { get; set; } = string.Empty;
        public List<EstImagenBuilder> Imagenes { get; set; } = [];
    }
}
