namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
public class Conestmi{
    public int C7fec1 { get; set; }
    public int C7fec2 { get; set; }
    public int C7dmin { get; set; }
    public char C7peri { get; set; }
    public string C7thab { get; set; } = string.Empty;
    public string C7regi { get; set; } = string.Empty;
    public int C7agen { get; set; }
    public int C7sucu { get; set; }
    public int C7agcl { get; set; }
    public int C7sucl { get; set; }
    public int C7hote { get; set; }
    public string C7cont { get; set; } = string.Empty;
    public int Cofec1 { get; set; }
    public int C7vers { get; set; }
    public int C7Lin { get; set; }    

    public string GetNewCode => $"{GetContractClientCode}{C7Lin}";
    public string GetContractClientCode => $"{C7hote}{C7cont}{Cofec1}{C7vers}{C7agen}{C7sucu}{C7agcl}{C7sucl}";
}
