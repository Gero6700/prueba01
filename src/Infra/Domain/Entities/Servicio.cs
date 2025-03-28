namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Entities;
public class Servicio {
    public int Id { get; set; }
    public ServicioCategoria Categoria { get; set; } = new ServicioCategoria();
    public string EsServicio { get; set; } = string.Empty;
    public string EnServicio { get; set; } = string.Empty;
    public string DeServicio { get; set; } = string.Empty;
    public string FrServicio { get; set; } = string.Empty;
    public string PtServicio { get; set; } = string.Empty;
}
