namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class ConestmiBuilder {
    private ConestmiRaw raw = null!;

    public static ConestmiBuilder AConestmiBuilder() {
        return new ConestmiBuilder {
            raw = GenerateRaw()
        };
    }

    public ConestmiBuilder WithC7fec1(int newC7fec1) {
        raw.C7fec1 = newC7fec1;
        return this;
    }

    public ConestmiBuilder WithC7fec2(int newC7fec2) {
        raw.C7fec2 = newC7fec2;
        return this;
    }

    public ConestmiBuilder WithC7dmin(int newC7dmin) {
        raw.C7dmin = newC7dmin;
        return this;
    }

    public ConestmiBuilder WithC7peri(char newC7peri) {
        raw.C7peri = newC7peri;
        return this;
    }

    public ConestmiBuilder WithC7thab(string newC7thab) {
        raw.C7thab = newC7thab;
        return this;
    }

    public ConestmiBuilder WithC7regi(string newC7regi) {
        raw.C7regi = newC7regi;
        return this;
    }

    public ConestmiBuilder WithC7agen(int newC7agen) {
        raw.C7agen = newC7agen;
        return this;
    }

    public ConestmiBuilder WithC7sucu(int newC7sucu) {
        raw.C7sucu = newC7sucu;
        return this;
    }

    public ConestmiBuilder WithC7agcl(int newC7agcl) {
        raw.C7agcl = newC7agcl;
        return this;
    }

    public ConestmiBuilder WithC7sucl(int newC7sucl) {
        raw.C7sucl = newC7sucl;
        return this;
    }

    public ConestmiBuilder WithC7hote(int newC7hote) {
        raw.C7hote = newC7hote;
        return this;
    }

    public ConestmiBuilder WithC7cont(string newC7cont) {
        raw.C7cont = newC7cont;
        return this;
    }

    public ConestmiBuilder WithCofec1(int newCofec1) {
        raw.Cofec1 = newCofec1;
        return this;
    }

    public ConestmiBuilder WithC7vers(int newC7vers) {
        raw.C7vers = newC7vers;
        return this;
    }

    public ConestmiBuilder WithC7Lin(int newC7Lin) {
        raw.C7Lin = newC7Lin;
        return this;
    }

    public Conestmi Build() {
        return new Faker<Conestmi>()
            .RuleFor(x => x.C7fec1, raw.C7fec1)
            .RuleFor(x => x.C7fec2, raw.C7fec2)
            .RuleFor(x => x.C7dmin, raw.C7dmin)
            .RuleFor(x => x.C7peri, raw.C7peri)
            .RuleFor(x => x.C7thab, raw.C7thab)
            .RuleFor(x => x.C7regi, raw.C7regi)
            .RuleFor(x => x.C7agen, raw.C7agen)
            .RuleFor(x => x.C7sucu, raw.C7sucu)
            .RuleFor(x => x.C7agcl, raw.C7agcl)
            .RuleFor(x => x.C7sucl, raw.C7sucl)
            .RuleFor(x => x.C7hote, raw.C7hote)
            .RuleFor(x => x.C7cont, raw.C7cont)
            .RuleFor(x => x.Cofec1, raw.Cofec1)
            .RuleFor(x => x.C7vers, raw.C7vers)
            .RuleFor(x => x.C7Lin, raw.C7Lin)
            .Generate();
    }

    private static ConestmiRaw GenerateRaw() {
        return new Faker<ConestmiRaw>()
            .RuleFor(x => x.C7fec1, f => (DateTime.Now.Year * 1000) + f.Random.Number(0, 365))
            .RuleFor(x => x.C7fec2, f => ((DateTime.Now.Year + 1) * 1000) + f.Random.Number(0, 365))
            .RuleFor(x => x.C7dmin, f => f.Random.Int(0,99))
            .RuleFor(x => x.C7peri, f => f.Random.Char('A','Z'))
            .RuleFor(x => x.C7thab, f => f.Random.String(2,'A', 'Z'))
            .RuleFor(x => x.C7regi, f => f.Random.String(2, 'A', 'Z'))
            .RuleFor(x => x.C7agen, f => f.Random.Int(10000, 99999))
            .RuleFor(x => x.C7sucu, f => f.Random.Int(1, 99))
            .RuleFor(x => x.C7agcl, f => f.Random.Int(10000, 99999))
            .RuleFor(x => x.C7sucl, f => f.Random.Int(1, 99))
            .RuleFor(x => x.C7hote, f => f.Random.Int(0,999))
            .RuleFor(x => x.C7cont, f => f.Random.AlphaNumeric(2).ToUpper())
            .RuleFor(x => x.Cofec1, f => (DateTime.Now.Year * 1000) + f.Random.Number(0, 365))
            .RuleFor(x => x.C7vers, f => f.Random.Int(0, 99))
            .RuleFor(x => x.C7Lin, f => f.Random.Int(0, 99))
            .Generate();
    }

    private class ConestmiRaw {
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
    }
    
}
