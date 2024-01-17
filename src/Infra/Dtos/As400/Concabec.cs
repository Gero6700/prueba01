namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

public class Concabec {
    public int Coagen { get; set; }
    public int Cosucu { get; set; }
    public int Cohote { get; set; }
    public string Cocont { get; set; } = string.Empty;
    public int Cofec1 { get; set; }
    public int Cofec2 { get; set; }
    public string Codesc { get; set; } = string.Empty;
    public decimal Cohf { get; set; }
    public decimal Corece { get; set; }
    public decimal Cotran { get; set; }
    public int Comone { get; set; }
    public decimal Cotrai { get; set; }
    public decimal Cocoag { get; set; }
    public int Coagcl { get; set; }
    public int Cosucl { get; set; }
    public decimal Cococl { get; set; }
    public string Coiva { get; set; } = string.Empty;
    public string Cocore { get; set; } = string.Empty;
    public string Cofact { get; set; } = string.Empty;
    public string Cofpag { get; set; } = string.Empty;
    public string Copfcc { get; set; } = string.Empty;
    public string Cocuga { get; set; } = string.Empty;
    public decimal Coencu { get; set; }
    public string Coenct { get; set; } = string.Empty;
    public string Coencd { get; set; } = string.Empty;
    public string Coidio { get; set; } = string.Empty;
    public string Coconf { get; set; } = string.Empty;
    public int Cogcno { get; set; }
    public decimal Cogcpo { get; set; }
    public decimal Cogcim { get; set; }
    public string Cogcto { get; set; } = string.Empty;
    public int Cogcho { get; set; }
    public string Coest { get; set; } = string.Empty;
    public string Copgm { get; set; } = string.Empty;
    public int Cocarp { get; set; }
    public int Cosubc { get; set; }
    public string Coasig { get; set; } = string.Empty;
    public int Cofext { get; set; }
    public int Covers { get; set; }
    public string Cobaco { get; set; } = string.Empty;
    public string Cobacc { get; set; } = string.Empty;
    public string Cocose { get; set; } = string.Empty;
    public string Cotemp { get; set; } = string.Empty;
    public decimal Cocpor { get; set; }
    public int Cocage { get; set; }
    public int Cocsuc { get; set; }
    public int Cocagc { get; set; }
    public int Cocscl { get; set; }
    public int Cochot { get; set; }
    public string Coccto { get; set; } = string.Empty;
    public int Cocver { get; set; }
    public int Cocfe1 { get; set; }
    public decimal Codde1 { get; set; }
    public string Codco1 { get; set; } = string.Empty;
    public decimal Codde2 { get; set; }
    public string Codco2 { get; set; } = string.Empty;
    public decimal Copalo { get; set; }
    public decimal Codpto { get; set; }
    public string Cofode { get; set; } = string.Empty;
    public int Coftop { get; set; }
    //Merca
    public string Codmerca { get; set; } = string.Empty;
    //Concabed
    public decimal Cenimi { get; set; }
    public decimal Cenima { get; set; }
    public decimal Ceinmi { get; set; }
    public decimal Ceinma { get; set; }
    //Condtos
    public decimal D4desd { get; set; }
    public decimal D4hast { get; set; }
    //servxml.usureg
    public long Idusuario { get; set; }
    
    public string GetNewCode => $"{Cohote}{Cocont}{Cofec1}{Covers}";

}