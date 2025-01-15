namespace Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
public class Conofege {
    public required string Id { get; set; } = string.Empty;
    public required string Fechamodi { get; set; } = string.Empty;
    public required string Code { get; set; } = string.Empty;
    public required string Ccode { get; set; } = string.Empty;
    public required string OfDesc { get; set; } = string.Empty;
    public required string Ofopci { get; set; } = string.Empty;
    public required int Offec { get; set; }
    public required int Offec2 { get; set; }
    public required decimal Ofdpto { get; set; }
    public required string Offode { get; set; } = string.Empty;
    public required int Offtop { get; set; }
    public required string Ofties { get; set; } = string.Empty;
    public required string Ofadni { get; set; } = string.Empty;
    public required int Ofdiae { get; set; }
    public required int Ofdiaf { get; set; }
    public required int Ofdieh { get; set; }
    public required int Offred { get; set; }
    public required int Offres { get; set; }
    public required int Ofgrbd { get; set; }
    public required int Ofgrbh { get; set; }
    public required int Ofcocu { get; set; }
    public required string Ofdfac { get; set; } = string.Empty;
    public required string Ofthaf { get; set; } = string.Empty;
    public required string Oftsef { get; set; } = string.Empty;
    public required string Offore { get; set; } = string.Empty;
    public required decimal Ofpree { get; set; }
    public required string Offors { get; set; } = string.Empty;
    public required decimal Ofpres { get; set; }
    public required decimal Ofdtos { get; set; }
    public required string Oftidt { get; set; } = string.Empty;
    public required string Ofsobr { get; set; } = string.Empty;
    public required string Ofapli { get; set; } = string.Empty;
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
    public required string Ofthab { get; set; } = string.Empty;
    public required string Oftha2 { get; set; } = string.Empty;
    public required string Oftha3 { get; set; } = string.Empty;
    public required string Oftha4 { get; set; } = string.Empty;
    public required string Oftha5 { get; set; } = string.Empty;
    public required string Oftha6 { get; set; } = string.Empty;
    public required string Oftha7 { get; set; } = string.Empty;
    public required string Oftha8 { get; set; } = string.Empty;
    public required string Oftha9 { get; set; } = string.Empty;
    public required string Ofth10 { get; set; } = string.Empty;
    public required string Ofth11 { get; set; } = string.Empty;
    public required string Ofth12 { get; set; } = string.Empty;
    public required string Ofth13 { get; set; } = string.Empty;
    public required string Ofth14 { get; set; } = string.Empty;
    public required string Ofth15 { get; set; } = string.Empty;
    public required string Oftser { get; set; } = string.Empty;
    public required string Oftse2 { get; set; } = string.Empty;
    public required string Oftse3 { get; set; } = string.Empty;
    public required string Oftse4 { get; set; } = string.Empty;
    public required string Oftse5 { get; set; } = string.Empty;
    //Congasmo
    public required decimal Gmimpo { get; set; }
    public required int Ofpri { get; set; }
    public List<string> GetRoomCodes => new() { Ofthab, Oftha2, Oftha3, Oftha4, Oftha5, Oftha6, Oftha7, Oftha8, Oftha9, Ofth10, Ofth11, Ofth12, Ofth13, Ofth14, Ofth15 };
    public List<string> GetRegimeCodes => new() { Oftser, Oftse2, Oftse3, Oftse4, Oftse5 };

    //public List<decimal> GetAdultStayDiscounts => new () { Ofdae1, Ofdae2, Ofdae3, Ofdae4 };
    //public List<decimal> GetAdultRegimeDiscounts => new() { Ofdas1, Ofdas2, Ofdas3, Ofdas4 };
    //public List<decimal> GetChildStayDiscounts => new() { Ofdne1, Ofdne2, Ofdne3, Ofdne4 };
    //public List<decimal> GetChildRegimeDiscounts => new() { Ofdns1, Ofdns2, Ofdns3, Ofdns4 };
}
