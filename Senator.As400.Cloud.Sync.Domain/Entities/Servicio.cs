namespace Senator.As400.Cloud.Sync.Domain.Entities;
public class Servicio {
    public int Id { get; set; }
    //public ServicioCategoria Categoria { get; set; } = new ServicioCategoria();
    public string EsServicio { get; set; } = string.Empty;
    public string EnServicio { get; set; } = string.Empty;
    public string DeServicio { get; set; } = string.Empty;
    public string FrServicio { get; set; } = string.Empty;
    public string PtServicio { get; set; } = string.Empty;

    public string EsDetalle { get; set; } = string.Empty;
    public string EnDetalle { get; set; } = string.Empty;
    public string FrDetalle { get; set; } = string.Empty;
    public string DeDetalle { get; set; } = string.Empty;
    public string PtDetalle { get; set; } = string.Empty;

    public int IdCategoria { get; set; }
}
