namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class ConofegeBuilder {
    private ConofegeRaw raw = null!;

    public static ConofegeBuilder AConofegeBuilder() {
        return new ConofegeBuilder {
            raw = GenerateRaw()
        };
    }

    private static ConofegeRaw GenerateRaw() {
        return new Faker<ConofegeRaw>()
            .RuleFor(x => x.Code, f => f.Random.String(10,'A','Z').ToUpper())
            .RuleFor(x => x.ContractClientCode, f => f.Random.String(10,'A','Z').ToUpper())
            .RuleFor(x => x.Ofopci, f => f.Random.ArrayElement(new string[] {"S", ""}))
            .RuleFor(x => x.Offec, f => (DateTime.Now.Year * 1000) + f.Random.Int(1, 365))
            .RuleFor(x => x.Offec2, f => ((DateTime.Now.Year + 1) * 1000) + f.Random.Int(1, 365))
            .RuleFor(x => x.Ofdpto, f => f.Random.Decimal())
            .RuleFor(x => x.Offode, f => f.Random.ArrayElement(new string[] {"%", "I", ""}))
            .RuleFor(x => x.Offtop, f => int.Parse(f.Date.Future().ToString("yyMMdd")))
            .RuleFor(x => x.Ofties, f => f.Random.ArrayElement(new string[] {"L", "P", "E", ""}))
            .RuleFor(x => x.Ofadni, f => f.Random.ArrayElement(new string[] {"T", "A", "N", ""}))
            .RuleFor(x => x.Ofdiae, f => f.Random.Int(0,99))
            .RuleFor(x => x.Ofdiaf, f => f.Random.Int(0,99))
            .RuleFor(x => x.Ofdieh, (_, x) => x.Ofdiae + 1)
            .RuleFor(x => x.Offred, f => f.Random.Int(0,99))
            .RuleFor(x => x.Offres, (_, x) => x.Offred + 1)
            .RuleFor(x => x.Ofgrbd, f => (DateTime.Now.Year * 1000) + f.Random.Number(0,365))
            .RuleFor(x => x.Ofgrbh, f => ((DateTime.Now.Year + 1) * 1000) + f.Random.Number(0,365))
            .RuleFor(x => x.Ofcocu, f => f.Random.Int(0,999))
            .RuleFor(x => x.Ofdfac, f => f.Random.ArrayElement(new string[] {"", "R"}))
            .RuleFor(x => x.Ofthaf, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftsef, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Offore, f => f.Random.ArrayElement(new string[] {"D", "P", "U", "X", ""}))
            .RuleFor(x => x.Ofpree, f => f.Random.Decimal(0,100))
            .RuleFor(x => x.Offors, f => f.Random.ArrayElement(new string[] {"D", "P", "U", "X", ""}))
            .RuleFor(x => x.Ofpres, f => f.Random.Decimal(0,100))
            .RuleFor(x => x.Ofdtos, f => f.Random.Decimal(0,100))
            .RuleFor(x => x.Oftidt, f => f.Random.ArrayElement(new string[] {"C", ""}))
            .RuleFor(x => x.Ofsobr, f => f.Random.ArrayElement(new string[] {"B", "C", ""}))
            .RuleFor(x => x.Ofapli, f => f.Random.ArrayElement(new string[] {"E", "S", ""}))
            .RuleFor(x => x.Ofthab, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftha2, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftha3, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftha4, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftha5, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftha6, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftha7, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftha8, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftha9, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Ofth10, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Ofth11, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Ofth12, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Ofth13, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Ofth14, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Ofth15, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftser, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftse2, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftse3, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftse4, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Oftse5, f => f.Random.String(1,'A','Z').ToUpper())
            .RuleFor(x => x.Gmimpo, f => f.Random.Decimal(0,200))
            .Generate();
    }

    public Conofege Build() {
        return new Conofege {
            Code = raw.Code,
            ContractClientCode = raw.ContractClientCode,
            Ofopci = raw.Ofopci,
            Offec = raw.Offec,
            Offec2 = raw.Offec2,
            Ofdpto = raw.Ofdpto,
            Offode = raw.Offode,
            Offtop = raw.Offtop,
            Ofties = raw.Ofties,
            Ofadni = raw.Ofadni,
            Ofdiae = raw.Ofdiae,
            Ofdiaf = raw.Ofdiaf,
            Ofdieh = raw.Ofdieh,
            Offred = raw.Offred,
            Offres = raw.Offres,
            Ofgrbd = raw.Ofgrbd,
            Ofgrbh = raw.Ofgrbh,
            Ofcocu = raw.Ofcocu,
            Ofdfac = raw.Ofdfac,
            Ofthaf = raw.Ofthaf,
            Oftsef = raw.Oftsef,
            Offore = raw.Offore,
            Ofpree = raw.Ofpree,
            Offors = raw.Offors,
            Ofpres = raw.Ofpres,
            Ofdtos = raw.Ofdtos,
            Oftidt = raw.Oftidt,
            Ofsobr = raw.Ofsobr,
            Ofapli = raw.Ofapli,
            Ofthab = raw.Ofthab,
            Oftha2 = raw.Oftha2,
            Oftha3 = raw.Oftha3,
            Oftha4 = raw.Oftha4,
            Oftha5 = raw.Oftha5,
            Oftha6 = raw.Oftha6,
            Oftha7 = raw.Oftha7,
            Oftha8 = raw.Oftha8,
            Oftha9 = raw.Oftha9,
            Ofth10 = raw.Ofth10,
            Ofth11 = raw.Ofth11,
            Ofth12 = raw.Ofth12,
            Ofth13 = raw.Ofth13,
            Ofth14 = raw.Ofth14,
            Ofth15 = raw.Ofth15,
            Oftser = raw.Oftser,
            Oftse2 = raw.Oftse2,
            Oftse3 = raw.Oftse3,
            Oftse4 = raw.Oftse4,
            Oftse5 = raw.Oftse5,
            Gmimpo = raw.Gmimpo
        };
    }

    public ConofegeBuilder WithCode(string newCode) {
        raw.Code = newCode;
        return this;
    }

    public ConofegeBuilder WithContractClientCode(string newContractClientCode) {
        raw.ContractClientCode = newContractClientCode;
        return this;
    }

    public ConofegeBuilder WithOfopci(string newOfopci) {
        raw.Ofopci = newOfopci;
        return this;
    }

    public ConofegeBuilder WithOffec(int newOffec) {
        raw.Offec = newOffec;
        return this;
    }

    public ConofegeBuilder WithOffec2(int newOffec2) {
        raw.Offec2 = newOffec2;
        return this;
    }

    public ConofegeBuilder WithOfdpto(decimal newOfdpto) {
        raw.Ofdpto = newOfdpto;
        return this;
    }

    public ConofegeBuilder WithOffode(string newOffode) {
        raw.Offode = newOffode;
        return this;
    }

    public ConofegeBuilder WithOfftop(int newOfftop) {
        raw.Offtop = newOfftop;
        return this;
    }

    public ConofegeBuilder WithOfties(string newOfties) {
        raw.Ofties = newOfties;
        return this;
    }

    public ConofegeBuilder WithOfadni(string newOfadni) {
        raw.Ofadni = newOfadni;
        return this;
    }

    public ConofegeBuilder WithOfdiae(int newOfdiae) {
        raw.Ofdiae = newOfdiae;
        return this;
    }

    public ConofegeBuilder WithOfdiaf(int newOfdiaf) {
        raw.Ofdiaf = newOfdiaf;
        return this;
    }

    public ConofegeBuilder WithOfdieh(int newOfdieh) {
        raw.Ofdieh = newOfdieh;
        return this;
    }

    public ConofegeBuilder WithOffred(int newOffred) {
        raw.Offred = newOffred;
        return this;
    }

    public ConofegeBuilder WithOffres(int newOffres) {
        raw.Offres = newOffres;
        return this;
    }

    public ConofegeBuilder WithOfgrbd(int newOfgrbd) {
        raw.Ofgrbd = newOfgrbd;
        return this;
    }

    public ConofegeBuilder WithOfgrbh(int newOfgrbh) {
        raw.Ofgrbh = newOfgrbh;
        return this;
    }

    public ConofegeBuilder WithOfcocu(int newOfcocu) {
        raw.Ofcocu = newOfcocu;
        return this;
    }

    public ConofegeBuilder WithOfdfac(string newOfdfac) {
        raw.Ofdfac = newOfdfac;
        return this;
    }

    public ConofegeBuilder WithOfthaf(string newOfthaf) {
        raw.Ofthaf = newOfthaf;
        return this;
    }

    public ConofegeBuilder WithOftsef(string newOftsef) {
        raw.Oftsef = newOftsef;
        return this;
    }

    public ConofegeBuilder WithOffore(string newOffore) {
        raw.Offore = newOffore;
        return this;
    }

    public ConofegeBuilder WithOfpree(decimal newOfpree) {
        raw.Ofpree = newOfpree;
        return this;
    }

    public ConofegeBuilder WithOffors(string newOffors) {
        raw.Offors = newOffors;
        return this;
    }

    public ConofegeBuilder WithOfpres(decimal newOfpres) {
        raw.Ofpres = newOfpres;
        return this;
    }

    public ConofegeBuilder WithOfdtos(decimal newOfdtos) {
        raw.Ofdtos = newOfdtos;
        return this;
    }

    public ConofegeBuilder WithOftidt(string newOftidt) {
        raw.Oftidt = newOftidt;
        return this;
    }

    public ConofegeBuilder WithOfsobr(string newOfsobr) {
        raw.Ofsobr = newOfsobr;
        return this;
    }

    public ConofegeBuilder WithOfapli(string newOfapli) {
        raw.Ofapli = newOfapli;
        return this;
    }

    public ConofegeBuilder WithOfthab(string newOfthab) {
        raw.Ofthab = newOfthab;
        return this;
    }

    public ConofegeBuilder WithOftha2(string newOftha2) {
        raw.Oftha2 = newOftha2;
        return this;
    }

    public ConofegeBuilder WithOftha3(string newOftha3) {
        raw.Oftha3 = newOftha3;
        return this;
    }

    public ConofegeBuilder WithOftha4(string newOftha4) {
        raw.Oftha4 = newOftha4;
        return this;
    }

    public ConofegeBuilder WithOftha5(string newOftha5) {
        raw.Oftha5 = newOftha5;
        return this;
    }

    public ConofegeBuilder WithOftha6(string newOftha6) {
        raw.Oftha6 = newOftha6;
        return this;
    }

    public ConofegeBuilder WithOftha7(string newOftha7) {
        raw.Oftha7 = newOftha7;
        return this;
    }

    public ConofegeBuilder WithOftha8(string newOftha8) {
        raw.Oftha8 = newOftha8;
        return this;
    }

    public ConofegeBuilder WithOftha9(string newOftha9) {
        raw.Oftha9 = newOftha9;
        return this;
    }

    public ConofegeBuilder WithOfth10(string newOfth10) {
        raw.Ofth10 = newOfth10;
        return this;
    }

    public ConofegeBuilder WithOfth11(string newOfth11) {
        raw.Ofth11 = newOfth11;
        return this;
    }

    public ConofegeBuilder WithOfth12(string newOfth12) {
        raw.Ofth12 = newOfth12;
        return this;
    }

    public ConofegeBuilder WithOfth13(string newOfth13) {
        raw.Ofth13 = newOfth13;
        return this;
    }

    public ConofegeBuilder WithOfth14(string newOfth14) {
        raw.Ofth14 = newOfth14;
        return this;
    }

    public ConofegeBuilder WithOfth15(string newOfth15) {
        raw.Ofth15 = newOfth15;
        return this;
    }

    public ConofegeBuilder WithOftser(string newOftser) {
        raw.Oftser = newOftser;
        return this;
    }

    public ConofegeBuilder WithOftse2(string newOftse2) {
        raw.Oftse2 = newOftse2;
        return this;
    }

    public ConofegeBuilder WithOftse3(string newOftse3) {
        raw.Oftse3 = newOftse3;
        return this;
    }

    public ConofegeBuilder WithOftse4(string newOftse4) {
        raw.Oftse4 = newOftse4;
        return this;
    }

    public ConofegeBuilder WithOftse5(string newOftse5) {
        raw.Oftse5 = newOftse5;
        return this;
    }

    public ConofegeBuilder WithGmimpo(decimal newGmimpo) {
        raw.Gmimpo = newGmimpo;
        return this;
    }

    public ConofegeBuilder WithOfthab(string[] newOfthab) {
        raw.Ofthab = newOfthab[0];
        raw.Oftha2 = newOfthab[1];
        raw.Oftha3 = newOfthab[2];
        raw.Oftha4 = newOfthab[3];
        raw.Oftha5 = newOfthab[4];
        raw.Oftha6 = newOfthab[5];
        raw.Oftha7 = newOfthab[6];
        raw.Oftha8 = newOfthab[7];
        raw.Oftha9 = newOfthab[8];
        raw.Ofth10 = newOfthab[9];
        raw.Ofth11 = newOfthab[10];
        raw.Ofth12 = newOfthab[11];
        raw.Ofth13 = newOfthab[12];
        raw.Ofth14 = newOfthab[13];
        raw.Ofth15 = newOfthab[14];
        return this;
    }

    public ConofegeBuilder WithOftser(string[] newOftser) {
        raw.Oftser = newOftser[0];
        raw.Oftse2 = newOftser[1];
        raw.Oftse3 = newOftser[2];
        raw.Oftse4 = newOftser[3];
        raw.Oftse5 = newOftser[4];
        return this;
    }

    private class ConofegeRaw {
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
        public decimal Gmimpo { get; set; }
    }
}
