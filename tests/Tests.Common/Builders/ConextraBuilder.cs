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
            .RuleFor(x => x.Code, f => f.Random.String())
            .RuleFor(x => x.C5fred, f => (DateTime.Now.Year * 1000) + f.Random.Int(0, 365))
            .RuleFor(x => x.C5freh, f => ((DateTime.Now.Year + 1) * 1000) + f.Random.Int(0, 365))
            .RuleFor(x => x.C5fec1, f => (DateTime.Now.Year * 1000) + f.Random.Int(0, 365))
            .RuleFor(x => x.C5fec2, f => ((DateTime.Now.Year + 1) * 1000) + f.Random.Int(0, 365))
            .RuleFor(x => x.C5died, f => f.Random.Int(1, 99))
            .RuleFor(x => x.C5dieh, (_, x) => x.C5died + 1)
            .RuleFor(x => x.C5Sele, f => f.Random.String(1, 'A', 'S').ToUpper())
            .RuleFor(x => x.C5unid, f => f.Random.Int(1, 99))
            .RuleFor(x => x.C5inta, f => f.Random.Int(1, 99))
            .RuleFor(x => x.C5foun, f => f.Random.ArrayElement(new string[] { "D", "P", "U", "X" }))
            .RuleFor(x => x.C5prec, f => f.Random.Decimal())
            .RuleFor(x => x.C5form, f => f.Random.ArrayElement(new string[] { "D", "P", "U", "X" }))
            .RuleFor(x => x.C5apdt, f => f.Random.ArrayElement(new string[] { "C", "S", "" }))
            .RuleFor(x => x.Cogc, f => f.Random.Bool())
            .RuleFor(x => x.C5cocu, f => f.Random.Int(0, 99))
            .Generate();
    }

    public ConextraBuilder WithCode(string newCode) {
        raw.Code = newCode;
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

    public ConextraBuilder WithCogc(bool newCogc) {
        raw.Cogc = newCogc;
        return this;
    }

    public ConextraBuilder WithC5cocu(int newC5cocu) {
        raw.C5cocu = newC5cocu;
        return this;
    }

    public Conextra Build() {
        return new Faker<Conextra>()
            .RuleFor(x => x.Code, raw.Code)
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
            .RuleFor(x => x.Cogc, raw.Cogc)
            .RuleFor(x => x.C5cocu, raw.C5cocu)
            .Generate();

    }

    private class ConextraRaw {
        public string Code { get; set; } = string.Empty;
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
        public bool Cogc { get; set; }
        public int C5cocu { get; set; } 
    }
}
