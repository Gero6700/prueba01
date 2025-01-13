namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
public class Usureg {
    public required string Id { get; set; } = string.Empty;
    public required string Fechamodi { get; set; } = string.Empty;
    public long IdUsuario { get; set; }
    public required string Usuario { get; set; } = string.Empty;
    public required string Clave { get; set; } = string.Empty;  
    public required string NombreComercial { get; set; } = string.Empty;
    //Restagen
    public required char AgGroup { get; set; }
}

