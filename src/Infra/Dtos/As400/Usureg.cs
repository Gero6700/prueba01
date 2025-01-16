namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
public class Usureg {
    public required string Id { get; set; } 
    public required string Fechamodi { get; set; } 
    public long IdUsuario { get; set; }
    public required string Usuario { get; set; } 
    public required string Clave { get; set; }   
    public required string NombreComercial { get; set; } 
    //Restagen
    public required char AgGroup { get; set; }
}

