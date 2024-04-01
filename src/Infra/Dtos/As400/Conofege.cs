namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
public class Conofege {
    public string Code { get; set; } = string.Empty;
    public string ContractClientCode { get; set; } = string.Empty;
    public string Ofopci { get; set; } = string.Empty;
    public int Offec { get; set; }
    public int Offec2 { get; set; }
    public decimal Ofdpto { get; set; }
    public string Offode { get; set; } = string.Empty;
    public int Offtop { get; set; }
    public string Ofties { get; set; } = string.Empty;
    public string Ofadni { get; set; } = string.Empty;
    public int Ofdiae { get; set; }
    public int Ofdiaf { get; set; }
    public int Ofdieh { get; set; }
    public int Offred { get; set; }
    public int Offres { get; set; }
    public int Ofgrbd { get; set; }
    public int Ofgrbh { get; set; }
    public int Ofcocu { get; set; }
    public string Ofdfac { get; set; } = string.Empty;
    public string Ofthaf { get; set; } = string.Empty;
    public string Oftsef { get; set; } = string.Empty;
    public string Offore { get; set; } = string.Empty;
    public decimal Ofpree { get; set; }
    public string Offors { get; set; } = string.Empty;
    public decimal Ofpres { get; set; }
    public decimal Ofdtos { get; set; }
    public string Oftidt { get; set; } = string.Empty;
    public string Ofsobr { get; set; } = string.Empty;
    public string Ofapli { get; set; } = string.Empty;
    //public decimal Ofdae1 { get; set; }
    //public decimal Ofdae2 { get; set; }
    //public decimal Ofdae3 { get; set; }
    //public decimal Ofdae4 { get; set; }
    //public decimal Ofdas1 { get; set; }
    //public decimal Ofdas2 { get; set; }
    //public decimal Ofdas3 { get; set; }
    //public decimal Ofdas4 { get; set; }
    //public decimal Ofdne1 { get; set; }
    //public decimal Ofdne2 { get; set; }
    //public decimal Ofdne3 { get; set; }
    //public decimal Ofdne4 { get; set; }
    //public decimal Ofdns1 { get; set; }
    //public decimal Ofdns2 { get; set; }
    //public decimal Ofdns3 { get; set; }
    //public decimal Ofdns4 { get; set; }
    public string Ofthab { get; set; } = string.Empty;
    public string Oftha2 { get; set; } = string.Empty;
    public string Oftha3 { get; set; } = string.Empty;
    public string Oftha4 { get; set; } = string.Empty;
    public string Oftha5 { get; set; } = string.Empty;
    public string Oftha6 { get; set; } = string.Empty;
    public string Oftha7 { get; set; } = string.Empty;
    public string Oftha8 { get; set; } = string.Empty;
    public string Oftha9 { get; set; } = string.Empty;
    public string Ofth10 { get; set; } = string.Empty;
    public string Ofth11 { get; set; } = string.Empty;
    public string Ofth12 { get; set; } = string.Empty;
    public string Ofth13 { get; set; } = string.Empty;
    public string Ofth14 { get; set; } = string.Empty;
    public string Ofth15 { get; set; } = string.Empty;
    public string Oftser { get; set; } = string.Empty;
    public string Oftse2 { get; set; } = string.Empty;
    public string Oftse3 { get; set; } = string.Empty;
    public string Oftse4 { get; set; } = string.Empty;
    public string Oftse5 { get; set; } = string.Empty;
    //Congasmo
    public decimal Gmimpo { get; set; } 
    public List<string> GetRoomCodes => new () { Ofthab, Oftha2, Oftha3, Oftha4, Oftha5, Oftha6, Oftha7, Oftha8, Oftha9, Ofth10, Ofth11, Ofth12, Ofth13, Ofth14, Ofth15 };
    public List<string> GetRegimeCodes => new () { Oftser, Oftse2, Oftse3, Oftse4, Oftse5 };
    //public List<decimal> GetAdultStayDiscounts => new () { Ofdae1, Ofdae2, Ofdae3, Ofdae4 };
    //public List<decimal> GetAdultRegimeDiscounts => new() { Ofdas1, Ofdas2, Ofdas3, Ofdas4 };
    //public List<decimal> GetChildStayDiscounts => new() { Ofdne1, Ofdne2, Ofdne3, Ofdne4 };
    //public List<decimal> GetChildRegimeDiscounts => new() { Ofdns1, Ofdns2, Ofdns3, Ofdns4 };
}
