namespace Senator.As400.Cloud.Sync.Domain.Entities;

[Table("EST_hoteles")]
public class Hotel(
    string uid,
    int codigoInterno,
    string nombreHotel,
    DateTime? cerradoDesde,
    DateTime? cerradoHasta,
    string codigoCategoria,
    string nombreMarcaComercial,
    string codigoTipoHotel,
    string director,
    int numeroHabitaciones,
    int numeroPlantas,
    int anioConstruccion,
    string esPais,
    int codigoPais,
    string nombreProvincia,
    int codigoProvincia,
    string nombreLocalidad,
    string codigoLocalidad,
    string domicilio,
    string codigoPostal,
    string gmapsLatitud,
    string gmapsLongitud,
    string telefono,
    string fax,
    string email,
    string web,
    decimal edadMinNino,
    decimal edadMaxNino,
    decimal edadMinBebe,
    decimal edadMaxBebe,
    string esEntradilla,
    string esDescripcion,
    string esSituacion,
    string enEntradilla,
    string enDescripcion,
    string enSituacion,
    string frEntradilla,
    string frDescripcion,
    string frSituacion,
    string deEntradilla,
    string deDescripcion,
    string deSituacion,
    string ptEntradilla,
    string ptDescripcion,
    string ptSituacion) {

    [Column("uid")]
    public string Uid { get; set; } = uid;

    [Column("codigo_interno")]
    public int CodigoInterno { get; set; } = codigoInterno;

    [Column("nombre_hotel")]
    public string NombreHotel { get; set; } = nombreHotel;

    [Column("cerrado_desde")]
    public DateTime? CerradoDesde { get; set; } = cerradoDesde;

    [Column("cerrado_hasta")]
    public DateTime? CerradoHasta { get; set; } = cerradoHasta;

    [Column("codigo_categoria")]
    public string CodigoCategoria { get; set; } = codigoCategoria;

    [Column("nombre_marca_comercial")]
    public string NombreMarcaComercial { get; set; } = nombreMarcaComercial;

    [Column("codigo_tipo_hotel")]
    public string CodigoTipoHotel { get; set; } = codigoTipoHotel;

    [Column("director")]
    public string Director { get; set; } = director;

    [Column("numero_habitaciones")]
    public int NumeroHabitaciones { get; set; } = numeroHabitaciones;

    [Column("numero_plantas")]
    public int NumeroPlantas { get; set; } = numeroPlantas;

    [Column("anio_construccion")]
    public int AnioConstruccion { get; set; } = anioConstruccion;

    [Column("es_pais")]
    public string EsPais { get; set; } = esPais;

    [Column("codigo_pais")]
    public int CodigoPais { get; set; } = codigoPais;

    [Column("nombre_provincia")]
    public string NombreProvincia { get; set; } = nombreProvincia;

    [Column("codigo_provincia")]
    public int CodigoProvincia { get; set; } = codigoProvincia;

    [Column("nombre_localidad")]
    public string NombreLocalidad { get; set; } = nombreLocalidad;

    [Column("codigo_localidad")]
    public string CodigoLocalidad { get; set; } = codigoLocalidad;

    [Column("domicilio")]
    public string Domicilio { get; set; } = domicilio;

    [Column("codigo_postal")]
    public string CodigoPostal { get; set; } = codigoPostal;

    [Column("gmaps_latitud")]
    public string GmapsLatitud { get; set; } = gmapsLatitud;

    [Column("gmaps_longitud")]
    public string GmapsLongitud { get; set; } = gmapsLongitud;

    [Column("telefono")]
    public string Telefono { get; set; } = telefono;

    [Column("fax")]
    public string Fax { get; set; } = fax;

    [Column("email")]
    public string Email { get; set; } = email;

    [Column("web")]
    public string Web { get; set; } = web;

    [Column("edad_min_nino")]
    public decimal EdadMinNino { get; set; } = edadMinNino;

    [Column("edad_max_nino")]
    public decimal EdadMaxNino { get; set; } = edadMaxNino;

    [Column("edad_min_bebe")]
    public decimal EdadMinBebe { get; set; } = edadMinBebe;

    [Column("edad_max_bebe")]
    public decimal EdadMaxBebe { get; set; } = edadMaxBebe;

    [Column("es_entradilla")]
    public string EsEntradilla { get; set; } = esEntradilla;

    [Column("es_descripcion")]
    public string EsDescripcion { get; set; } = esDescripcion;

    [Column("es_situacion")]
    public string EsSituacion { get; set; } = esSituacion;

    [Column("en_entradilla")]
    public string EnEntradilla { get; set; } = enEntradilla;

    [Column("en_descripcion")]
    public string EnDescripcion { get; set; } = enDescripcion;

    [Column("en_situacion")]
    public string EnSituacion { get; set; } = enSituacion;

    [Column("fr_entradilla")]
    public string FrEntradilla { get; set; } = frEntradilla;

    [Column("fr_descripcion")]
    public string FrDescripcion { get; set; } = frDescripcion;

    [Column("fr_situacion")]
    public string FrSituacion { get; set; } = frSituacion;

    [Column("de_entradilla")]
    public string DeEntradilla { get; set; } = deEntradilla;

    [Column("de_descripcion")]
    public string DeDescripcion { get; set; } = deDescripcion;

    [Column("de_situacion")]
    public string DeSituacion { get; set; } = deSituacion;

    [Column("pt_entradilla")]
    public string PtEntradilla { get; set; } = ptEntradilla;

    [Column("pt_descripcion")]
    public string PtDescripcion { get; set; } = ptDescripcion;

    [Column("pt_situacion")]
    public string PtSituacion { get; set; } = ptSituacion;

    public IEnumerable<Imagen> Imagenes { get; set; } = [];
    public IEnumerable<string> RegimenesCodes { get; set; } = [];
    public IEnumerable<Piscina> Piscinas { get; set; } = [];
    public IEnumerable<Imagen> PiscinasImagenes { get; set; } =  [];
    public IEnumerable<Habitacion> Habitaciones { get; set; } = [];
    public IEnumerable<Imagen> HabitacionesImagenes { get; set; } = [];
    public IEnumerable<CamaTipo> HabitacionesCamas { get; set; } = [];
    public IEnumerable<HabitacionServicio> HabitacionesServicios { get; set; } = [];
    public IEnumerable<Salon> Salones { get; set; } = [];
    public IEnumerable<Imagen> SalonesImagenes { get; set; } = [];
    public IEnumerable<int> ServiciosIds { get; set; } = [];

    public Hotel() : this(
        string.Empty,
        0,
        string.Empty,
        null,
        null,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        0,
        0,
        0,
        string.Empty,
        0,
        string.Empty,
        0,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        0,
        0,
        0,
        0,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty,
        string.Empty
        ) {} // Default constructor for EF Core
}