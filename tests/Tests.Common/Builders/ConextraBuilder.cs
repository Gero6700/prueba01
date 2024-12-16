using Newtonsoft.Json.Linq;

namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;

public class ConextraBuilder {
    private ConextraRaw raw = null!;

    public static ConextraBuilder AConextraBuilder() {
        return new ConextraBuilder {
            raw = GenerateRaw()
        };
    }

    private static ConextraRaw GenerateRaw() {
        return new Faker<ConextraRaw>()
            .RuleFor(x => x.Code, f => f.Random.String(10,'A','Z').ToUpper())
            .RuleFor(x => x.OriginCode, f => f.Random.String(10,'A','Z').ToUpper())
            .RuleFor(x => x.OriginType, f => f.PickRandom<OriginType>())
            .RuleFor(x => x.C5fred, f => (DateTime.Now.Year * 1000) + f.Random.Int(1, 365))
            .RuleFor(x => x.C5freh, f => ((DateTime.Now.Year + 1) * 1000) + f.Random.Int(1, 365))
            .RuleFor(x => x.C5fec1, f => (DateTime.Now.Year * 1000) + f.Random.Int(1, 365))
            .RuleFor(x => x.C5fec2, f => ((DateTime.Now.Year + 1) * 1000) + f.Random.Int(1, 365))
            .RuleFor(x => x.C5died, f => f.Random.Int(1, 99))
            .RuleFor(x => x.C5dieh, (_, x) => x.C5died + 1)
            .RuleFor(x => x.C5Sele, f => f.Random.String(1, 'A', 'S').ToUpper())
            .RuleFor(x => x.C5unid, f => f.Random.Int(1, 99))
            .RuleFor(x => x.C5inta, f => f.Random.Int(1, 99))
            .RuleFor(x => x.C5foun, f => f.Random.ArrayElement(new string[] { "D", "P", "U", "X" }))
            .RuleFor(x => x.C5prec, f => f.Random.Decimal())
            .RuleFor(x => x.C5form, f => f.Random.ArrayElement(new string[] { "D", "P", "U", "X" }))
            .RuleFor(x => x.C5apdt, f => f.Random.ArrayElement(new string[] { "C", "S", "" }))
            .RuleFor(x => x.C5cocu, f => f.Random.Int(0, 99))
            .RuleFor(x => x.C5dtn1, f => f.Random.Decimal(0, 100))
            .RuleFor(x => x.C5dtn2, f => f.Random.Decimal(0, 100))
            .RuleFor(x => x.C5dtn3, f => f.Random.Decimal(0, 100))
            .RuleFor(x => x.C5dtn4, f => f.Random.Decimal(0, 100))
            .RuleFor(x => x.C5dta1, f => f.Random.Decimal(0, 100))
            .RuleFor(x => x.C5dta2, f => f.Random.Decimal(0, 100))
            .RuleFor(x => x.C5dta3, f => f.Random.Decimal(0, 100))
            .RuleFor(x => x.C5dta4, f => f.Random.Decimal(0, 100))
            .RuleFor(x => x.C5th01, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th02, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th03, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th04, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th05, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th06, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th07, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th08, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th09, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th10, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th11, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th12, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th13, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th14, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5th15, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5reg1, f => f.Random.String(2, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5reg2, f => f.Random.String(2, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5reg3, f => f.Random.String(2, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5reg4, f => f.Random.String(2, 'A', 'Z').ToUpper())
            .RuleFor(x => x.C5reg5, f => f.Random.String(2, 'A', 'Z').ToUpper())
            .RuleFor(x => x.Offoe, f => f.Random.String(1, 'A', 'Z').ToUpper())
            .Generate();
    }

    public ConextraBuilder WithCode(string newCode) {
        raw.Code = newCode;
        return this;
    }

    public ConextraBuilder WithOriginCode(string newOriginCode) {
        raw.OriginCode = newOriginCode;
        return this;
    }

    public ConextraBuilder WithOriginType(OriginType newOriginType) {
        raw.OriginType = newOriginType;
        return this;
    }

    public ConextraBuilder WithC5fred(int newC5fred) {
        raw.C5fred = newC5fred;
        return this;
    }

    public ConextraBuilder WithC5freh(int newC5freh) {
        raw.C5freh = newC5freh;
        return this;
    }

    public ConextraBuilder WithC5fec1(int newC5fec1) {
        raw.C5fec1 = newC5fec1;
        return this;
    }

    public ConextraBuilder WithC5fec2(int newC5fec2) {
        raw.C5fec2 = newC5fec2;
        return this;
    }

    public ConextraBuilder WithC5died(int newC5died) {
        raw.C5died = newC5died;
        return this;
    }

    public ConextraBuilder WithC5dieh(int newC5dieh) {
        raw.C5dieh = newC5dieh;
        return this;
    }

    public ConextraBuilder WithC5Sele(string newC5Sele) {
        raw.C5Sele = newC5Sele;
        return this;
    }

    public ConextraBuilder WithC5unid(int newC5unid) {
        raw.C5unid = newC5unid;
        return this;
    }

    public ConextraBuilder WithC5inta(int newC5inta) {
        raw.C5inta = newC5inta;
        return this;
    }

    public ConextraBuilder WithC5foun(string newC5foun) {
        raw.C5foun = newC5foun;
        return this;
    }

    public ConextraBuilder WithC5prec(decimal newC5prec) {
        raw.C5prec = newC5prec;
        return this;
    }

    public ConextraBuilder WithC5form(string newC5form) {
        raw.C5form = newC5form;
        return this;
    }

    public ConextraBuilder WithC5apdt(string newC5apdt) {
        raw.C5apdt = newC5apdt;
        return this;
    }

    public ConextraBuilder WithC5cocu(int newC5cocu) {
        raw.C5cocu = newC5cocu;
        return this;
    }

    public ConextraBuilder WithC5dtn1(decimal newC5dtn1) {
        raw.C5dtn1 = newC5dtn1;
        return this;
    }

    public ConextraBuilder WithC5dtn2(decimal newC5dtn2) {
        raw.C5dtn2 = newC5dtn2;
        return this;
    }

    public ConextraBuilder WithC5dtn3(decimal newC5dtn3) {
        raw.C5dtn3 = newC5dtn3;
        return this;
    }

    public ConextraBuilder WithC5dtn4(decimal newC5dtn4) {
        raw.C5dtn4 = newC5dtn4;
        return this;
    }

    public ConextraBuilder WithC5dta1(decimal newC5dta1) {
        raw.C5dta1 = newC5dta1;
        return this;
    }

    public ConextraBuilder WithC5dta2(decimal newC5dta2) {
        raw.C5dta2 = newC5dta2;
        return this;
    }

    public ConextraBuilder WithC5dta3(decimal newC5dta3) {
        raw.C5dta3 = newC5dta3;
        return this;
    }

    public ConextraBuilder WithC5dta4(decimal newC5dta4) {
        raw.C5dta4 = newC5dta4;
        return this;
    }

    public ConextraBuilder WithC5th01(string newC5th01) {
        raw.C5th01 = newC5th01;
        return this;
    }

    public ConextraBuilder WithC5th02(string newC5th02) {
        raw.C5th02 = newC5th02;
        return this;
    }

    public ConextraBuilder WithC5th03(string newC5th03) {
        raw.C5th03 = newC5th03;
        return this;
    }

    public ConextraBuilder WithC5th04(string newC5th04) {
        raw.C5th04 = newC5th04;
        return this;
    }

    public ConextraBuilder WithC5th05(string newC5th05) {
        raw.C5th05 = newC5th05;
        return this;
    }

    public ConextraBuilder WithC5th06(string newC5th06) {
        raw.C5th06 = newC5th06;
        return this;
    }

    public ConextraBuilder WithC5th07(string newC5th07) {
        raw.C5th07 = newC5th07;
        return this;
    }

    public ConextraBuilder WithC5th08(string newC5th08) {
        raw.C5th08 = newC5th08;
        return this;
    }

    public ConextraBuilder WithC5th09(string newC5th09) {
        raw.C5th09 = newC5th09;
        return this;
    }

    public ConextraBuilder WithC5th10(string newC5th10) {
        raw.C5th10 = newC5th10;
        return this;
    }

    public ConextraBuilder WithC5th11(string newC5th11) {
        raw.C5th11 = newC5th11;
        return this;
    }

    public ConextraBuilder WithC5th12(string newC5th12) {
        raw.C5th12 = newC5th12;
        return this;
    }

    public ConextraBuilder WithC5th13(string newC5th13) {
        raw.C5th13 = newC5th13;
        return this;
    }

    public ConextraBuilder WithC5th14(string newC5th14) {
        raw.C5th14 = newC5th14;
        return this;
    }

    public ConextraBuilder WithC5th15(string newC5th15) {
        raw.C5th15 = newC5th15;
        return this;
    }

    public ConextraBuilder WithC5reg1(string newC5reg1) {
        raw.C5reg1 = newC5reg1;
        return this;
    }

    public ConextraBuilder WithC5reg2(string newC5reg2) {
        raw.C5reg2 = newC5reg2;
        return this;
    }

    public ConextraBuilder WithC5reg3(string newC5reg3) {
        raw.C5reg3 = newC5reg3;
        return this;
    }

    public ConextraBuilder WithC5reg4(string newC5reg4) {
        raw.C5reg4 = newC5reg4;
        return this;
    }

    public ConextraBuilder WithC5reg5(string newC5reg5) {
        raw.C5reg5 = newC5reg5;
        return this;
    }

    public ConextraBuilder WithOffoe(string newOffoe) {
        raw.Offoe = newOffoe;
        return this;
    }

    public Conextra Build() {
        return new Faker<Conextra>()
            .RuleFor(x => x.Code, raw.Code)
            .RuleFor(x => x.OriginCode, raw.OriginCode)
            .RuleFor(x => x.OriginType, raw.OriginType)
            .RuleFor(x => x.C5fred, raw.C5fred)
            .RuleFor(x => x.C5freh, raw.C5freh)
            .RuleFor(x => x.C5fec1, raw.C5fec1)
            .RuleFor(x => x.C5fec2, raw.C5fec2)
            .RuleFor(x => x.C5died, raw.C5died)
            .RuleFor(x => x.C5dieh, raw.C5dieh)
            .RuleFor(x => x.C5Sele, raw.C5Sele)
            .RuleFor(x => x.C5unid, raw.C5unid)
            .RuleFor(x => x.C5inta, raw.C5inta)
            .RuleFor(x => x.C5foun, raw.C5foun)
            .RuleFor(x => x.C5prec, raw.C5prec)
            .RuleFor(x => x.C5form, raw.C5form)
            .RuleFor(x => x.C5apdt, raw.C5apdt)
            .RuleFor(x => x.C5cocu, raw.C5cocu)
            .RuleFor(x => x.C5dtn1, raw.C5dtn1)
            .RuleFor(x => x.C5dtn2, raw.C5dtn2)
            .RuleFor(x => x.C5dtn3, raw.C5dtn3)
            .RuleFor(x => x.C5dtn4, raw.C5dtn4)
            .RuleFor(x => x.C5dta1, raw.C5dta1)
            .RuleFor(x => x.C5dta2, raw.C5dta2)
            .RuleFor(x => x.C5dta3, raw.C5dta3)
            .RuleFor(x => x.C5dta4, raw.C5dta4)
            .RuleFor(x => x.C5th01, raw.C5th01)
            .RuleFor(x => x.C5th02, raw.C5th02)
            .RuleFor(x => x.C5th03, raw.C5th03)
            .RuleFor(x => x.C5th04, raw.C5th04)
            .RuleFor(x => x.C5th05, raw.C5th05)
            .RuleFor(x => x.C5th06, raw.C5th06)
            .RuleFor(x => x.C5th07, raw.C5th07)
            .RuleFor(x => x.C5th08, raw.C5th08)
            .RuleFor(x => x.C5th09, raw.C5th09)
            .RuleFor(x => x.C5th10, raw.C5th10)
            .RuleFor(x => x.C5th11, raw.C5th11)
            .RuleFor(x => x.C5th12, raw.C5th12)
            .RuleFor(x => x.C5th13, raw.C5th13)
            .RuleFor(x => x.C5th14, raw.C5th14)
            .RuleFor(x => x.C5th15, raw.C5th15)
            .RuleFor(x => x.C5reg1, raw.C5reg1)
            .RuleFor(x => x.C5reg2, raw.C5reg2)
            .RuleFor(x => x.C5reg3, raw.C5reg3)
            .RuleFor(x => x.C5reg4, raw.C5reg4)
            .RuleFor(x => x.C5reg5, raw.C5reg5)
            .RuleFor(x => x.Offoe, raw.Offoe)
            .Generate();

    }

    private class ConextraRaw {
        public string Code { get; set; } = string.Empty;
        public string OriginCode { get; set; } = string.Empty;
        public OriginType OriginType { get; set; }
        public int C5fred { get; set; }
        public int C5freh { get; set; }
        public int C5fec1 { get; set; }
        public int C5fec2 { get; set; }
        public int C5died { get; set; }
        public int C5dieh { get; set; }
        public string C5Sele { get; set; } = string.Empty;
        public int C5unid { get; set; }
        public int C5inta { get; set; }
        public string C5foun { get; set; } = string.Empty;
        public decimal C5prec { get; set; }
        public string C5form { get; set; } = string.Empty;
        public string C5apdt { get; set; } = string.Empty;
        public int C5cocu { get; set; }
        public decimal C5dtn1 { get; set; }
        public decimal C5dtn2 { get; set; }
        public decimal C5dtn3 { get; set; }
        public decimal C5dtn4 { get; set; }
        public decimal C5dta1 { get; set; }
        public decimal C5dta2 { get; set; }
        public decimal C5dta3 { get; set; }
        public decimal C5dta4 { get; set; }
        public string C5th01 { get; set; } = string.Empty;
        public string C5th02 { get; set; } = string.Empty;
        public string C5th03 { get; set; } = string.Empty;
        public string C5th04 { get; set; } = string.Empty;
        public string C5th05 { get; set; } = string.Empty;
        public string C5th06 { get; set; } = string.Empty;
        public string C5th07 { get; set; } = string.Empty;
        public string C5th08 { get; set; } = string.Empty;
        public string C5th09 { get; set; } = string.Empty;
        public string C5th10 { get; set; } = string.Empty;
        public string C5th11 { get; set; } = string.Empty;
        public string C5th12 { get; set; } = string.Empty;
        public string C5th13 { get; set; } = string.Empty;
        public string C5th14 { get; set; } = string.Empty;
        public string C5th15 { get; set; } = string.Empty;
        public string C5reg1 { get; set; } = string.Empty;
        public string C5reg2 { get; set; } = string.Empty;
        public string C5reg3 { get; set; } = string.Empty;
        public string C5reg4 { get; set; } = string.Empty;
        public string C5reg5 { get; set; } = string.Empty;
        public string Offoe { get; set; } = string.Empty;
    }
}
