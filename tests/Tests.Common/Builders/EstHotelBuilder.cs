using Senator.As400.Cloud.Sync.Infrastructure.Dtos.SqlServer;

namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class EstHotelBuilder {
    private EstHotelRaw raw = null!;

    public static EstHotelBuilder AnEstHotelBuilder() {
        return new EstHotelBuilder {
            raw = GenerateRaw()
        };
    }

    public EstHotelBuilder WithCodigoInterno(int newCodigoInterno) {
        raw.CodigoInterno = newCodigoInterno;
        return this;
    }

    public EstHotelBuilder WithNombreHotel(string newNombreHotel) {
        raw.NombreHotel = newNombreHotel;
        return this;
    }

    public EstHotelBuilder WithCodigoCategoria(string newCodigoCategoria) {
        raw.CodigoCategoria = newCodigoCategoria;
        return this;
    }

    public EstHotelBuilder WithNombreMarcaComercial(string newNombreMarcaComercial) {
        raw.NombreMarcaComercial = newNombreMarcaComercial;
        return this;
    }

    public EstHotelBuilder WithCodigoTipoHotel(string newCodigoTipoHotel) {
        raw.CodigoTipoHotel = newCodigoTipoHotel;
        return this;
    }

    public EstHotelBuilder WithDirector(string newDirector) {
        raw.Director = newDirector;
        return this;
    }

    public EstHotelBuilder WithNumeroHabitaciones(int newNumeroHabitaciones) {
        raw.NumeroHabitaciones = newNumeroHabitaciones;
        return this;
    }

    public EstHotelBuilder WithNumeroPlantas(int newNumeroPlantas) {
        raw.NumeroPlantas = newNumeroPlantas;
        return this;
    }

    public EstHotelBuilder WithAnioConstruccion(int newAnioConstruccion) {
        raw.AnioConstruccion = newAnioConstruccion;
        return this;
    }

    public EstHotelBuilder WithEsPais(string newEsPais) {
        raw.EsPais = newEsPais;
        return this;
    }

    public EstHotelBuilder WithCodigoPaisIso(string newCodigoPaisIso) {
        raw.CodigoPaisIso = newCodigoPaisIso;
        return this;
    }

    public EstHotelBuilder WithNombreProvincia(string newNombreProvincia) {
        raw.NombreProvincia = newNombreProvincia;
        return this;
    }

    public EstHotelBuilder WithCodigoProvinciaIso(string newCodigoProvinciaIso) {
        raw.CodigoProvinciaIso = newCodigoProvinciaIso;
        return this;
    }

    public EstHotelBuilder WithNombreLocalidad(string newNombreLocalidad) {
        raw.NombreLocalidad = newNombreLocalidad;
        return this;
    }

    public EstHotelBuilder WithCodigoLocalidad(string newCodigoLocalidad) {
        raw.CodigoLocalidad = newCodigoLocalidad;
        return this;
    }

    public EstHotelBuilder WithDomicilio(string newDomicilio) {
        raw.Domicilio = newDomicilio;
        return this;
    }

    public EstHotelBuilder WithCodigoPostal(string newCodigoPostal) {
        raw.CodigoPostal = newCodigoPostal;
        return this;
    }

    public EstHotelBuilder WithGmapsLatitud(string newGmapsLatitud) {
        raw.GmapsLatitud = newGmapsLatitud;
        return this;
    }

    public EstHotelBuilder WithGmapsLongitud(string newGmapsLongitud) {
        raw.GmapsLongitud = newGmapsLongitud;
        return this;
    }

    public EstHotelBuilder WithTelefono(string newTelefono) {
        raw.Telefono = newTelefono;
        return this;
    }

    public EstHotelBuilder WithFax(string newFax) {
        raw.Fax = newFax;
        return this;
    }

    public EstHotelBuilder WithEmail(string newEmail) {
        raw.Email = newEmail;
        return this;
    }

    public EstHotelBuilder WithWeb(string newWeb) {
        raw.Web = newWeb;
        return this;
    }

    public EstHotelBuilder WithEdadMinNino(decimal newEdadMinNino) {
        raw.EdadMinNino = newEdadMinNino;
        return this;
    }

    public EstHotelBuilder WithEdadMaxNino(decimal newEdadMaxNino) {
        raw.EdadMaxNino = newEdadMaxNino;
        return this;
    }

    public EstHotelBuilder WithEdadMinBebe(decimal newEdadMinBebe) {
        raw.EdadMinBebe = newEdadMinBebe;
        return this;
    }

    public EstHotelBuilder WithEdadMaxBebe(decimal newEdadMaxBebe) {
        raw.EdadMaxBebe = newEdadMaxBebe;
        return this;
    }

    public EstHotelBuilder WithEsEntradilla(string newEsEntradilla) {
        raw.EsEntradilla = newEsEntradilla;
        return this;
    }

    public EstHotelBuilder WithEsDescripcion(string newEsDescripcion) {
        raw.EsDescripcion = newEsDescripcion;
        return this;
    }

    public EstHotelBuilder WithEsSituacion(string newEsSituacion) {
        raw.EsSituacion = newEsSituacion;
        return this;
    }

    public EstHotelBuilder WithEnEntradilla(string newEnEntradilla) {
        raw.EnEntradilla = newEnEntradilla;
        return this;
    }

    public EstHotelBuilder WithEnDescripcion(string newEnDescripcion) {
        raw.EnDescripcion = newEnDescripcion;
        return this;
    }

    public EstHotelBuilder WithEnSituacion(string newEnSituacion) {
        raw.EnSituacion = newEnSituacion;
        return this;
    }

    public EstHotelBuilder WithFrEntradilla(string newFrEntradilla) {
        raw.FrEntradilla = newFrEntradilla;
        return this;
    }

    public EstHotelBuilder WithFrDescripcion(string newFrDescripcion) {
        raw.FrDescripcion = newFrDescripcion;
        return this;
    }        

    public EstHotelBuilder WithFrSituacion(string newFrSituacion) {
        raw.FrSituacion = newFrSituacion;
        return this;
    }

    public EstHotelBuilder WithDeEntradilla(string newDeEntradilla) {
        raw.DeEntradilla = newDeEntradilla;
        return this;
    }

    public EstHotelBuilder WithDeDescripcion(string newDeDescripcion) {
        raw.DeDescripcion = newDeDescripcion;
        return this;
    }

    public EstHotelBuilder WithDeSituacion(string newDeSituacion) {
        raw.DeSituacion = newDeSituacion;
        return this;
    }

    public EstHotelBuilder WithPtEntradilla(string newPtEntradilla) {
        raw.PtEntradilla = newPtEntradilla;
        return this;
    }

    public EstHotelBuilder WithPtDescripcion(string newPtDescripcion) {
        raw.PtDescripcion = newPtDescripcion;
        return this;
    }

    public EstHotelBuilder WithPtSituacion(string newPtSituacion) {
        raw.PtSituacion = newPtSituacion;
        return this;
    }

    public EstHotelBuilder WithImagenes(List<EstImagenBuilder> newImagenes) {
        raw.Imagenes = newImagenes;
        return this;
    }

    public EstHotelBuilder WithHabitaciones(List<EstHabitacionBuilder> newHabitaciones) {
        raw.Habitaciones = newHabitaciones;
        return this;
    }

    public EstHotelBuilder WithPiscinas(List<EstPiscinaBuilder> newPiscinas) {
        raw.Piscinas = newPiscinas;
        return this;
    }

    public EstHotelBuilder WithSalones(List<EstSalonBuilder> newSalones) {
        raw.Salones = newSalones;
        return this;
    }

    public EstHotelBuilder WithIdReszoims(List<string> newIdReszoims) {
        raw.IdReszoims = newIdReszoims;
        return this;
    }

    public EstHotelBuilder WithIdServicios(List<int> newIdServicios) {
        raw.IdServicios = newIdServicios;
        return this;
    }

    public EstHotel Build() {
        return new Faker<EstHotel>()
            .RuleFor(x => x.CodigoInterno, raw.CodigoInterno)
            .RuleFor(x => x.NombreHotel, raw.NombreHotel)
            .RuleFor(x => x.CodigoCategoria, raw.CodigoCategoria)
            .RuleFor(x => x.NombreMarcaComercial, raw.NombreMarcaComercial)
            .RuleFor(x => x.CodigoTipoHotel, raw.CodigoTipoHotel)
            .RuleFor(x => x.Director, raw.Director)
            .RuleFor(x => x.NumeroHabitaciones, raw.NumeroHabitaciones)
            .RuleFor(x => x.NumeroPlantas, raw.NumeroPlantas)
            .RuleFor(x => x.AnioConstruccion, raw.AnioConstruccion)
            .RuleFor(x => x.EsPais, raw.EsPais)
            .RuleFor(x => x.CodigoPaisIso, raw.CodigoPaisIso)
            .RuleFor(x => x.NombreProvincia, raw.NombreProvincia)
            .RuleFor(x => x.CodigoProvinciaIso, raw.CodigoProvinciaIso)
            .RuleFor(x => x.NombreLocalidad, raw.NombreLocalidad)
            .RuleFor(x => x.CodigoLocalidad, raw.CodigoLocalidad)
            .RuleFor(x => x.Domicilio, raw.Domicilio)
            .RuleFor(x => x.CodigoPostal, raw.CodigoPostal)
            .RuleFor(x => x.GmapsLatitud, raw.GmapsLatitud)
            .RuleFor(x => x.GmapsLongitud, raw.GmapsLongitud)
            .RuleFor(x => x.Telefono, raw.Telefono)
            .RuleFor(x => x.Fax, raw.Fax)
            .RuleFor(x => x.Email, raw.Email)
            .RuleFor(x => x.Web, raw.Web)
            .RuleFor(x => x.EdadMinNino, raw.EdadMinNino)
            .RuleFor(x => x.EdadMaxNino, raw.EdadMaxNino)
            .RuleFor(x => x.EdadMinBebe, raw.EdadMinBebe)
            .RuleFor(x => x.EdadMaxBebe, raw.EdadMaxBebe)
            .RuleFor(x => x.EsEntradilla, raw.EsEntradilla)
            .RuleFor(x => x.EsDescripcion, raw.EsDescripcion)
            .RuleFor(x => x.EsSituacion, raw.EsSituacion)
            .RuleFor(x => x.EnEntradilla, raw.EnEntradilla)
            .RuleFor(x => x.EnDescripcion, raw.EnDescripcion)
            .RuleFor(x => x.EnSituacion, raw.EnSituacion)
            .RuleFor(x => x.FrEntradilla, raw.FrEntradilla)
            .RuleFor(x => x.FrDescripcion, raw.FrDescripcion)
            .RuleFor(x => x.FrSituacion, raw.FrSituacion)
            .RuleFor(x => x.DeEntradilla, raw.DeEntradilla)                
            .RuleFor(x => x.DeDescripcion, raw.DeDescripcion)
            .RuleFor(x => x.DeSituacion, raw.DeSituacion)
            .RuleFor(x => x.PtEntradilla, raw.PtEntradilla)
            .RuleFor(x => x.PtDescripcion, raw.PtDescripcion)
            .RuleFor(x => x.PtSituacion, raw.PtSituacion)
            .RuleFor(x => x.Imagenes, raw.Imagenes.Select(x => x.Build()).ToList())
            .RuleFor(x => x.Habitaciones, raw.Habitaciones.Select(x => x.Build()).ToList())
            .RuleFor(x => x.Piscinas, raw.Piscinas.Select(x => x.Build()).ToList())
            .RuleFor(x => x.Salones, raw.Salones.Select(x => x.Build()).ToList())
            .RuleFor(x => x.IdReszoims, raw.IdReszoims)
            .RuleFor(x => x.IdServicios, raw.IdServicios)
            .Generate();
    }

    private static EstHotelRaw GenerateRaw() {
        return new Faker<EstHotelRaw>()
            .RuleFor(x => x.CodigoInterno, f => f.Random.Number(0, 999))
            .RuleFor(x => x.NombreHotel, f => f.Lorem.Sentence(2))
            .RuleFor(x => x.CodigoCategoria, f => f.Random.Number(1, 5) + "*")
            .RuleFor(x => x.NombreMarcaComercial, f => f.Lorem.Sentence(1))
            .RuleFor(x => x.CodigoTipoHotel, f => f.Random.String(2, 'A', 'Z'))
            .RuleFor(x => x.Director, f => f.Name.FullName())
            .RuleFor(x => x.NumeroHabitaciones, f => f.Random.Number(0, 999))
            .RuleFor(x => x.NumeroPlantas, f => f.Random.Number(0, 10))
            .RuleFor(x => x.AnioConstruccion, f => f.Random.Number(2000, 2022))
            .RuleFor(x => x.EsPais, f => f.Person.Address.State)
            .RuleFor(x => x.CodigoPaisIso, f => f.Random.String(2, 'A', 'Z'))
            .RuleFor(x => x.NombreProvincia, f => f.Person.Address.City)
            .RuleFor(x => x.CodigoProvinciaIso, f => f.Random.String(2, 'A', 'Z'))
            .RuleFor(x => x.NombreLocalidad, f => f.Person.Address.City)
            .RuleFor(x => x.CodigoLocalidad, f => f.Random.String(2, 'A', 'Z'))
            .RuleFor(x => x.Domicilio, f => f.Address.StreetAddress())
            .RuleFor(x => x.CodigoPostal, f => f.Address.ZipCode())
            .RuleFor(x => x.GmapsLatitud, f => f.Address.Latitude().ToString())
            .RuleFor(x => x.GmapsLongitud, f => f.Address.Longitude().ToString())
            .RuleFor(x => x.Telefono, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.Fax, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.Email, f => f.Internet.Email())
            .RuleFor(x => x.Web, f => f.Internet.Url())
            .RuleFor(x => x.EdadMinNino, f => f.Random.Number(3, 4))
            .RuleFor(x => x.EdadMaxNino, f => f.Random.Number(10, 13))
            .RuleFor(x => x.EdadMinBebe, f => f.Random.Number(0, 0))
            .RuleFor(x => x.EdadMaxBebe, f => f.Random.Number(2, 3))
            .RuleFor(x => x.EsEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.EsDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.EsSituacion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.EnEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.EnDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.EnSituacion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.FrEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.FrDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.FrSituacion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.DeEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.DeDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.DeSituacion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.PtEntradilla, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.PtDescripcion, f => f.Lorem.Sentence(10))
            .RuleFor(x => x.PtSituacion, f => f.Lorem.Sentence(5))
            .RuleFor(x => x.Imagenes, f => f.Make(f.Random.Number(1, 10), x => EstImagenBuilder.AnEstImagenBuilder()))
            .RuleFor(x => x.Habitaciones, f => f.Make(f.Random.Number(1, 5), x => EstHabitacionBuilder.AnEstHabitacionBuilder()))
            .RuleFor(x => x.Piscinas, f => f.Make(f.Random.Number(1, 5), x => EstPiscinaBuilder.AnEstPiscinaBuilder()))
            .RuleFor(x => x.Salones, f => f.Make(f.Random.Number(1, 5), x => EstSalonBuilder.AnEstSalonBuilder()))
            .RuleFor(x => x.IdReszoims, f => f.Make(f.Random.Number(1, 5), x => f.Random.String(10, 'A', 'Z')))
            .RuleFor(x => x.IdServicios, f => f.Make(f.Random.Number(1, 5), x => f.Random.Number(1, 999)))
            .Generate();
    }

    private class EstHotelRaw {
        public int CodigoInterno { get; set; }
        public string NombreHotel { get; set; } = string.Empty;
        public string CodigoCategoria { get; set; } = string.Empty;
        public string NombreMarcaComercial { get; set; } = string.Empty;
        public string CodigoTipoHotel { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int NumeroHabitaciones { get; set; }
        public int NumeroPlantas { get; set; }
        public int AnioConstruccion { get; set; }
        public string EsPais { get; set; } = string.Empty; 
        public string CodigoPaisIso { get; set; } = string.Empty;
        public string NombreProvincia { get; set; } = string.Empty;
        public string CodigoProvinciaIso { get; set; } = string.Empty;
        public string NombreLocalidad { get; set; } = string.Empty;
        public string CodigoLocalidad { get; set; } = string.Empty;
        public string Domicilio { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string GmapsLatitud { get; set; } = string.Empty;
        public string GmapsLongitud { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Fax { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Web { get; set; } = string.Empty;
        public decimal EdadMinNino { get; set; }
        public decimal EdadMaxNino { get; set; }
        public decimal EdadMinBebe { get; set; }
        public decimal EdadMaxBebe { get; set; }
        public string EsEntradilla { get; set; } = string.Empty;
        public string EsDescripcion { get; set; } = string.Empty;
        public string EsSituacion { get; set; } = string.Empty;
        public string EnEntradilla { get; set; } = string.Empty;
        public string EnDescripcion { get; set; } = string.Empty;
        public string EnSituacion { get; set; } = string.Empty;
        public string FrEntradilla { get; set; } = string.Empty;
        public string FrDescripcion { get; set; } = string.Empty;
        public string FrSituacion { get; set; } = string.Empty;
        public string DeEntradilla { get; set; } = string.Empty;
        public string DeDescripcion { get; set; } = string.Empty;
        public string DeSituacion { get; set; } = string.Empty;
        public string PtEntradilla { get; set; } = string.Empty;
        public string PtDescripcion { get; set; } = string.Empty;
        public string PtSituacion { get; set; } = string.Empty;
        public List<EstImagenBuilder> Imagenes { get; set; } = [];
        public List<EstHabitacionBuilder> Habitaciones { get; set; } = [];
        public List<EstPiscinaBuilder> Piscinas { get; set; } = [];
        public List<EstSalonBuilder> Salones { get; set; } = [];      
        public List<string> IdReszoims { get; set; } = [];
        public List<int> IdServicios { get; set; } = [];
    }
}
