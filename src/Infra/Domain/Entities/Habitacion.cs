namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Entities;
public class Habitacion {
    public int Id { get; set; }
    public string CodigoTipoHabitacion { get; set; } = string.Empty;
    public string Uid { get; set; } = string.Empty;
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
}
