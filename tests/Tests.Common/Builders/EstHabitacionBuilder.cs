namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class EstHabitacionBuilder {
    private EstHabitacionRaw raw = null!;

    public static EstHabitacionBuilder AnEstHabitacionBuilder() {
        return new EstHabitacionBuilder {
            raw = GenerateRaw()
        };
    }

    public EstHabitacionBuilder WithCodigoTipoHabitacion(string newCodigoTipoHabitacion) {
        raw.CodigoTipoHabitacion = newCodigoTipoHabitacion;
        return this;
    }

    public EstHabitacionBuilder WithNumeroHabitaciones(int newNumeroHabitaciones) {
        raw.NumeroHabitaciones = newNumeroHabitaciones;
        return this;
    }

    public EstHabitacionBuilder WithSuperficieAprox(decimal newSuperficieAprox) {
        raw.SuperficieAprox = newSuperficieAprox;
        return this;
    }

    public EstHabitacionBuilder WithPesoMinimo(decimal newPesoMinimo) {
        raw.PesoMinimo = newPesoMinimo;
        return this;
    }

    public EstHabitacionBuilder WithPesoMaximo(decimal newPesoMaximo) {
        raw.PesoMaximo = newPesoMaximo;
        return this;
    }

    public EstHabitacionBuilder WithMinBebes(int newMinBebes) {
        raw.MinBebes = newMinBebes;
        return this;
    }

    public EstHabitacionBuilder WithMaxBebes(int newMaxBebes) {
        raw.MaxBebes = newMaxBebes;
        return this;
    }

    public EstHabitacionBuilder WithMinNinos(int newMinNinos) {
        raw.MinNinos = newMinNinos;
        return this;
    }

    public EstHabitacionBuilder WithMaxNinos(int newMaxNinos) {
        raw.MaxNinos = newMaxNinos;
        return this;
    }

    public EstHabitacionBuilder WithMinAdultos(int newMinAdultos) {
        raw.MinAdultos = newMinAdultos;
        return this;
    }

    public EstHabitacionBuilder WithMaxAdultos(int newMaxAdultos) {
        raw.MaxAdultos = newMaxAdultos;
        return this;
    }

    public EstHabitacionBuilder WithEsNombreVerano(string newEsNombreVerano) {
        raw.EsNombreVerano = newEsNombreVerano;
        return this;
    }

    public EstHabitacionBuilder WithEnNombreVerano(string newEnNombreVerano) {
        raw.EnNombreVerano = newEnNombreVerano;
        return this;
    }

    public EstHabitacionBuilder WithFrNombreVerano(string newFrNombreVerano) {
        raw.FrNombreVerano = newFrNombreVerano;
        return this;
    }

    public EstHabitacionBuilder WithDeNombreVerano(string newDeNombreVerano) {
        raw.DeNombreVerano = newDeNombreVerano;
        return this;
    }

    public EstHabitacionBuilder WithPtNombreVerano(string newPtNombreVerano) {
        raw.PtNombreVerano = newPtNombreVerano;
        return this;
    }

    public EstHabitacionBuilder WithEsDescripcion(string newEsDescripcion) {
        raw.EsDescripcion = newEsDescripcion;
        return this;
    }

    public EstHabitacionBuilder WithEnDescripcion(string newEnDescripcion) {
        raw.EnDescripcion = newEnDescripcion;
        return this;
    }

    public EstHabitacionBuilder WithFrDescripcion(string newFrDescripcion) {
        raw.FrDescripcion = newFrDescripcion;
        return this;
    }

    public EstHabitacionBuilder WithDeDescripcion(string newDeDescripcion) {
        raw.DeDescripcion = newDeDescripcion;
        return this;
    }

    public EstHabitacionBuilder WithPtDescripcion(string newPtDescripcion) {
        raw.PtDescripcion = newPtDescripcion;
        return this;
    }

    public EstHabitacionBuilder WithEsEntradilla(string newEsEntradilla) {
        raw.EsEntradilla = newEsEntradilla;
        return this;
    }

    public EstHabitacionBuilder WithEnEntradilla(string newEnEntradilla) {
        raw.EnEntradilla = newEnEntradilla;
        return this;
    }

    public EstHabitacionBuilder WithFrEntradilla(string newFrEntradilla) {
        raw.FrEntradilla = newFrEntradilla;
        return this;
    }

    public EstHabitacionBuilder WithDeEntradilla(string newDeEntradilla) {
        raw.DeEntradilla = newDeEntradilla;
        return this;
    }

    public EstHabitacionBuilder WithPtEntradilla(string newPtEntradilla) {
        raw.PtEntradilla = newPtEntradilla;
        return this;
    }

    public EstHabitacionBuilder WithImagenes(List<EstImagenBuilder> newImagenes) {
        raw.Imagenes = newImagenes;
        return this;
    }

    public EstHabitacionBuilder WithCamas(List<EstCamaTipoBuilder> newCamas) {
        raw.Camas = newCamas;
        return this;
    }

    public EstHabitacion Build() {
        return new Faker<EstHabitacion>()
            .RuleFor(x => x.CodigoTipoHabitacion, raw.CodigoTipoHabitacion)
            .RuleFor(x => x.NumeroHabitaciones, raw.NumeroHabitaciones)
            .RuleFor(x => x.SuperficieAprox, raw.SuperficieAprox)
            .RuleFor(x => x.PesoMinimo, raw.PesoMinimo)
            .RuleFor(x => x.PesoMaximo, raw.PesoMaximo)
            .RuleFor(x => x.MinBebes, raw.MinBebes)
            .RuleFor(x => x.MaxBebes, raw.MaxBebes)
            .RuleFor(x => x.MinNinos, raw.MinNinos)
            .RuleFor(x => x.MaxNinos, raw.MaxNinos)
            .RuleFor(x => x.MinAdultos, raw.MinAdultos)
            .RuleFor(x => x.MaxAdultos, raw.MaxAdultos)
            .RuleFor(x => x.EsNombreVerano, raw.EsNombreVerano)
            .RuleFor(x => x.EnNombreVerano, raw.EnNombreVerano)
            .RuleFor(x => x.FrNombreVerano, raw.FrNombreVerano)
            .RuleFor(x => x.DeNombreVerano, raw.DeNombreVerano)
            .RuleFor(x => x.PtNombreVerano, raw.PtNombreVerano)
            .RuleFor(x => x.EsDescripcion, raw.EsDescripcion)
            .RuleFor(x => x.EnDescripcion, raw.EnDescripcion)
            .RuleFor(x => x.FrDescripcion, raw.FrDescripcion)
            .RuleFor(x => x.DeDescripcion, raw.DeDescripcion)
            .RuleFor(x => x.PtDescripcion, raw.PtDescripcion)
            .RuleFor(x => x.EsEntradilla, raw.EsEntradilla)
            .RuleFor(x => x.EnEntradilla, raw.EnEntradilla)
            .RuleFor(x => x.FrEntradilla, raw.FrEntradilla)
            .RuleFor(x => x.DeEntradilla, raw.DeEntradilla)
            .RuleFor(x => x.PtEntradilla, raw.PtEntradilla)
            .RuleFor(x => x.Imagenes, raw.Imagenes.Select(x => x.Build()).ToList())
            .RuleFor(x => x.Camas, raw.Camas.Select(x => x.Build()).ToList())
            .Generate();
    }

    private static EstHabitacionRaw GenerateRaw() {
        return new Faker<EstHabitacionRaw>()
            .RuleFor(x => x.CodigoTipoHabitacion, f => f.Random.String(2, 'A', 'B'))
            .RuleFor(x => x.NumeroHabitaciones, f => f.Random.Int(1, 99))
            .RuleFor(x => x.SuperficieAprox, f => f.Random.Decimal())
            .RuleFor(x => x.PesoMinimo, f => f.Random.Decimal())
            .RuleFor(x => x.PesoMaximo, f => f.Random.Decimal())
            .RuleFor(x => x.MinBebes, f => f.Random.Int(0, 1))
            .RuleFor(x => x.MaxBebes, f => f.Random.Int(1, 2))
            .RuleFor(x => x.MinNinos, f => f.Random.Int(0, 2))
            .RuleFor(x => x.MaxNinos, f => f.Random.Int(2, 4))
            .RuleFor(x => x.MinAdultos, f => f.Random.Int(1, 2))
            .RuleFor(x => x.MaxAdultos, f => f.Random.Int(2, 4))
            .RuleFor(x => x.EsNombreVerano, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EnNombreVerano, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.FrNombreVerano, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.DeNombreVerano, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.PtNombreVerano, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.EsDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.EnDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.FrDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.DeDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.PtDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.EsEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.EnEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.FrEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.DeEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.PtEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.Imagenes, f => f.Make(f.Random.Number(1, 5), x => EstImagenBuilder.AnEstImagenBuilder()))
            .RuleFor(x => x.Camas, f => f.Make(f.Random.Number(1, 2), x => EstCamaTipoBuilder.AnEstCamaTipoBuilder()))
            .Generate();
    }

    private class EstHabitacionRaw {
        public string CodigoTipoHabitacion { get; set; } = string.Empty;
        public int NumeroHabitaciones { get; set; }
        public decimal SuperficieAprox { get; set; }
        public decimal PesoMinimo { get; set; }
        public decimal PesoMaximo { get; set; }
        public int MinBebes { get; set; }
        public int MaxBebes { get; set; }
        public int MinNinos { get; set; }
        public int MaxNinos { get; set; }
        public int MinAdultos { get; set; }
        public int MaxAdultos { get; set; }
        public string EsNombreVerano { get; set; } = string.Empty;
        public string EnNombreVerano { get; set; } = string.Empty;
        public string FrNombreVerano { get; set; } = string.Empty;
        public string DeNombreVerano { get; set; } = string.Empty;
        public string PtNombreVerano { get; set; } = string.Empty;
        public string EsDescripcion { get; set; } = string.Empty;
        public string EnDescripcion { get; set; } = string.Empty;
        public string FrDescripcion { get; set; } = string.Empty;
        public string DeDescripcion { get; set; } = string.Empty;
        public string PtDescripcion { get; set; } = string.Empty;
        public string EsEntradilla { get; set; } = string.Empty;
        public string EnEntradilla { get; set; } = string.Empty;
        public string FrEntradilla { get; set; } = string.Empty;
        public string DeEntradilla { get; set; } = string.Empty;
        public string PtEntradilla { get; set; } = string.Empty;
        public List<EstImagenBuilder> Imagenes { get; set; } = [];
        public List<EstCamaTipoBuilder> Camas { get; set; } = [];
    }
}
