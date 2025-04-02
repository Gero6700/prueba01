namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Entities;
public class Salon{
    public int Id { get; set; }
    public string Uid { get; set; } = string.Empty;
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
}
