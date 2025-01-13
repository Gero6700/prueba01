namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

public class Restagen {
    public required string Id { get; set; } = string.Empty;
    public required string Fechamodi { get; set; } = string.Empty;
    public required char Mrcodi { get; set; }
    public string Mrtext { get; set; } = string.Empty;
}
