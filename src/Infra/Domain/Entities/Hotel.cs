namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Entities;
public class Hotel {
    public string Uid { get; set; } = string.Empty;
    public int CodigoInterno { get; set; }
    public string NombreHotel { get; set; } = string.Empty;
    public DateTime? CerradoDesde { get; set; }
    public DateTime? CerradoHasta { get; set; }
    public string CodigoCategoria { get; set; } = string.Empty;
    public string NombreMarcaComercial { get; set; } = string.Empty;
    public string CodigoTipoHotel { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int NumeroHabitaciones { get; set; }
    public int NumeroPlantas { get; set; }
    public int AnioConstruccion { get; set; }
    public string EsPais { get; set; } = string.Empty; //aux_paises
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
    //Description
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
    public IEnumerable<Imagen> Imagenes { get; set; } = [];
    public IEnumerable<Regimen> Regimenes { get; set; } = [];
    public IEnumerable<Piscina> Piscinas { get; set; } = [];
    public IEnumerable<Imagen> PiscinasImagenes { get; set; } = []; 

    public IEnumerable<Habitacion> Habitaciones { get; set; } = [];
    public IEnumerable<Imagen> HabitacionesImagenes { get; set; } = [];
    public IEnumerable<CamaTipo> HabitacionesCamas { get; set; } = [];
    public IEnumerable<Servicio> HabitacionesServicios { get; set; } = [];

    public IEnumerable<Salon> Salones { get; set; } = [];
    public IEnumerable<Imagen> SalonesImagenes { get; set; } = [];
    public IEnumerable<Servicio> Servicios { get; set; } = [];    
}
