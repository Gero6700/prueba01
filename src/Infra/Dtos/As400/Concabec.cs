namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

public class Concabec {
    public int Coagen { get; set; }
    public int Cosucu { get; set; }
    public int Cohote { get; set; }
    public string Cocont { get; set; } = string.Empty;
    public int Cofec1 { get; set; }
    public int Cofec2 { get; set; }
    public string Codesc { get; set; } = string.Empty;
    public int Comone { get; set; }
    public decimal Cocoag { get; set; }
    public int Coagcl { get; set; }
    public int Cosucl { get; set; }
    public string Coiva { get; set; } = string.Empty;
    public int Cofext { get; set; }
    public int Covers { get; set; }
    public string Cobaco { get; set; } = string.Empty;
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