namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

public class Concabec {
    public required string Id { get; set; } = string.Empty;
    public required string Fechamodi { get; set; } = string.Empty;
    public required string ContractCode { get; set; } = string.Empty;
    public required string ContractClientCode { get; set; } = string.Empty;
    public required int Cohote { get; set; }
    public required int Cofec1 { get; set; }
    public required int Cofec2 { get; set; }
    public required string Codesc { get; set; } = string.Empty;
    public required decimal Cocoag { get; set; }
    public required string Coiva { get; set; } = string.Empty;
    public required int Cofext { get; set; }
    public required string Cobaco { get; set; } = string.Empty;
    public required decimal Codpto { get; set; }
    public required string Cofode { get; set; } = string.Empty;
    public required int Coftop { get; set; }
    //Merca
    public required string Codmerca { get; set; } = string.Empty;
    //Concabed
    public required decimal Cenimi { get; set; }
    public required decimal Cenima { get; set; }
    public required decimal Ceinmi { get; set; }
    public required decimal Ceinma { get; set; }
    //Condtos
    public required decimal D4desd { get; set; }
    public required decimal D4hast { get; set; }
    //servxml.usureg
    public required long Idusuario { get; set; }
    //contgral.divisa
    public required string Dinom2 { get; set; } = string.Empty;

    public required decimal Cogcpo { get; set; }
    public required string Cocose { get; set; } = string.Empty;
}