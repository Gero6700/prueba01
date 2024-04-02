namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class ConestmiBuilder {
    private ConestmiRaw raw = null!;

    public static ConestmiBuilder AConestmiBuilder() {
        return new ConestmiBuilder {
            raw = GenerateRaw()
        };
    }

    public ConestmiBuilder WithCode(string newCode) {
        raw.Code = newCode;
        return this;
    }

    public ConestmiBuilder WithContractClientCode(string newContractClientCode) {
        raw.ContractClientCode = newContractClientCode;
        return this;
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

    public Conestmi Build() {
        return new Faker<Conestmi>()
            .RuleFor(x => x.Code, raw.Code)
            .RuleFor(x => x.ContractClientCode, raw.ContractClientCode)
            .RuleFor(x => x.C7fec1, raw.C7fec1)
            .RuleFor(x => x.C7fec2, raw.C7fec2)
            .RuleFor(x => x.C7dmin, raw.C7dmin)
            .RuleFor(x => x.C7peri, raw.C7peri)
            .RuleFor(x => x.C7thab, raw.C7thab)
            .RuleFor(x => x.C7regi, raw.C7regi)
            .Generate();
    }

    private static ConestmiRaw GenerateRaw() {
        return new Faker<ConestmiRaw>()
            .RuleFor(x => x.Code, f => f.Random.String(10, 'A', 'Z'))
            .RuleFor(x => x.ContractClientCode, f => f.Random.String(10, 'A', 'Z'))
            .RuleFor(x => x.C7fec1, f => int.Parse(f.Date.Future(0, DateTime.Now).ToString("yyyyMMdd")))
            .RuleFor(x => x.C7fec2, (f, x) => int.Parse(f.Date.Future(1, DateTime.Now).ToString("yyyyMMdd")))
            .RuleFor(x => x.C7dmin, f => f.Random.Int(0,99))
            .RuleFor(x => x.C7peri, f => f.Random.Char('A','Z'))
            .RuleFor(x => x.C7thab, f => f.Random.String(2,'A', 'Z'))
            .RuleFor(x => x.C7regi, f => f.Random.String(2, 'A', 'Z'))
            .Generate();
    }

    private class ConestmiRaw {
        public string Code { get; set; } = string.Empty;
        public string ContractClientCode { get; set; } = string.Empty;
        public int C7fec1 { get; set; }
        public int C7fec2 { get; set; }
        public int C7dmin { get; set; }
        public char C7peri { get; set; }
        public string C7thab { get; set; } = string.Empty;
        public string C7regi { get; set; } = string.Empty;
    }    
}
