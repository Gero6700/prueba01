namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.SqlServer;
public class EstPiscina {
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
    public List<EstImagen> Imagenes { get; set; } = [];
}
