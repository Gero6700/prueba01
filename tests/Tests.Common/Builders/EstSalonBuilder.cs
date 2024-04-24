namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class EstSalonBuilder{
    private EstSalonRaw raw = null!;

    public static EstSalonBuilder AnEstSalonBuilder() {
        return new EstSalonBuilder {
            raw = GenerateRaw()
        };
    }

    public EstSalonBuilder WithId(int newId) {
        raw.Id = newId;
        return this;
    }

    public EstSalonBuilder WithEsNombre(string newEsNombre) {
        raw.EsNombre = newEsNombre;
        return this;
    }

    public EstSalonBuilder WithSuperficie(decimal newSuperficie) {
        raw.Superficie = newSuperficie;
        return this;
    }

    public EstSalonBuilder WithAncho(decimal newAncho) {
        raw.Ancho = newAncho;
        return this;
    }

    public EstSalonBuilder WithLargo(decimal newLargo) {
        raw.Largo = newLargo;
        return this;
    }

    public EstSalonBuilder WithAltura(decimal newAltura) {
        raw.Altura = newAltura;
        return this;
    }

    public EstSalonBuilder WithAforoBanquete(int newAforoBanquete) {
        raw.AforoBanquete = newAforoBanquete;
        return this;
    }

    public EstSalonBuilder WithAforoCocktail(int newAforoCocktail) {
        raw.AforoCocktail = newAforoCocktail;
        return this;
    }

    public EstSalonBuilder WithAforoImperial(int newAforoImperial) {
        raw.AforoImperial = newAforoImperial;
        return this;
    }

    public EstSalonBuilder WithAforoU(int newAforoU) {
        raw.AforoU = newAforoU;
        return this;
    }

    public EstSalonBuilder WithAforoAula(int newAforoAula) {
        raw.AforoAula = newAforoAula;
        return this;
    }

    public EstSalonBuilder WithEsDescripcion(string newEsDescripcion) {
        raw.EsDescripcion = newEsDescripcion;
        return this;
    }

    public EstSalonBuilder WithEnDescripcion(string newEnDescripcion) {
        raw.EnDescripcion = newEnDescripcion;
        return this;
    }

    public EstSalonBuilder WithFrDescripcion(string newFrDescripcion) {
        raw.FrDescripcion = newFrDescripcion;
        return this;
    }

    public EstSalonBuilder WithDeDescripcion(string newDeDescripcion) {
        raw.DeDescripcion = newDeDescripcion;
        return this;
    }

    public EstSalonBuilder WithPtDescripcion(string newPtDescripcion) {
        raw.PtDescripcion = newPtDescripcion;
        return this;
    }

    public EstSalonBuilder WithImagenes(List<EstImagenBuilder> newImagenes) {
        raw.Imagenes = newImagenes;
        return this;
    }

    public EstSalon Build() {
        return new Faker<EstSalon>()
            .RuleFor(x => x.Id, raw.Id)
            .RuleFor(x => x.EsNombre, raw.EsNombre)
            .RuleFor(x => x.Superficie, raw.Superficie)
            .RuleFor(x => x.Ancho, raw.Ancho)
            .RuleFor(x => x.Largo, raw.Largo)
            .RuleFor(x => x.Altura, raw.Altura)
            .RuleFor(x => x.AforoBanquete, raw.AforoBanquete)
            .RuleFor(x => x.AforoCocktail, raw.AforoCocktail)
            .RuleFor(x => x.AforoImperial, raw.AforoImperial)
            .RuleFor(x => x.AforoU, raw.AforoU)
            .RuleFor(x => x.AforoAula, raw.AforoAula)
            .RuleFor(x => x.EsDescripcion, raw.EsDescripcion)
            .RuleFor(x => x.EnDescripcion, raw.EnDescripcion)
            .RuleFor(x => x.FrDescripcion, raw.FrDescripcion)
            .RuleFor(x => x.DeDescripcion, raw.DeDescripcion)
            .RuleFor(x => x.PtDescripcion, raw.PtDescripcion)
            .RuleFor(x => x.Imagenes, raw.Imagenes.Select(x => x.Build()).ToList())
            .Generate();
    }

    private static EstSalonRaw GenerateRaw() {
        return new Faker<EstSalonRaw>()
            .RuleFor(x => x.Id, f => f.Random.Number())
            .RuleFor(x => x.EsNombre, f => f.Random.String(10, 'A', 'Z'))
            .RuleFor(x => x.Superficie, f => f.Random.Decimal())
            .RuleFor(x => x.Ancho, f => f.Random.Decimal())
            .RuleFor(x => x.Largo, f => f.Random.Decimal())
            .RuleFor(x => x.Altura, f => f.Random.Decimal())
            .RuleFor(x => x.AforoBanquete, f => f.Random.Number())
            .RuleFor(x => x.AforoCocktail, f => f.Random.Number())
            .RuleFor(x => x.AforoImperial, f => f.Random.Number())
            .RuleFor(x => x.AforoU, f => f.Random.Number())
            .RuleFor(x => x.AforoAula, f => f.Random.Number())
            .RuleFor(x => x.EsDescripcion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.EnDescripcion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.FrDescripcion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.DeDescripcion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.PtDescripcion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.Imagenes, f => f.Make(f.Random.Number(1, 10), x => EstImagenBuilder.AnEstImagenBuilder()))
            .Generate();
    }

    private class EstSalonRaw {
        public int Id { get; set; }
        public string EsNombre { get; set; } = string.Empty;
        public decimal Superficie { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }
        public decimal Altura { get; set; }
        public int AforoBanquete { get; set; }
        public int AforoCocktail { get; set; }
        public int AforoImperial { get; set; }
        public int AforoU { get; set; }
        public int AforoAula { get; set; }
        public string EsDescripcion { get; set; } = string.Empty;
        public string EnDescripcion { get; set; } = string.Empty;
        public string FrDescripcion { get; set; } = string.Empty;
        public string DeDescripcion { get; set; } = string.Empty;
        public string PtDescripcion { get; set; } = string.Empty;
        public List<EstImagenBuilder> Imagenes { get; set; } = [];
    }
}
