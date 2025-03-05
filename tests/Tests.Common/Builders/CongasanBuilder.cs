namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class CongasanBuilder {
    private CongasanRaw raw = null!;

    public static CongasanBuilder ACongasanBuilder() {
        return new CongasanBuilder {
            raw = GenerateRaw()
        };
    }

    public CongasanBuilder WithCode(string newCode) {
        raw.Code = newCode;
        return this;
    }

    public CongasanBuilder WithOriginCode(string newOriginCode) {
        raw.OriginCode = newOriginCode;
        return this;
    }

    public CongasanBuilder WithOriginType(string newOriginType) {
        raw.OriginType = newOriginType;
        return this;
    }

    public CongasanBuilder WithC6fec1(string newC6fec1) {
        raw.C6fec1 = newC6fec1;
        return this;
    }

    public CongasanBuilder WithC6fec2(string newC6fec2) {
        raw.C6fec2 = newC6fec2;
        return this;
    }

    public CongasanBuilder WithC6gcdi(int newC6gcdi) {
        raw.C6gcdi = newC6gcdi;
        return this;
    }

    public CongasanBuilder WithC6gcho(int newC6gcho) {
        raw.C6gcho = newC6gcho;
        return this;
    }

    public CongasanBuilder WithC6gcno(int newC6gcno) {
        raw.C6gcno = newC6gcno;
        return this;
    }

    public CongasanBuilder WithC6gcpo(decimal newC6gcpo) {
        raw.C6gcpo = newC6gcpo;
        return this;
    }

    public CongasanBuilder WithC6gcim(decimal newC6gcim) {
        raw.C6gcim = newC6gcim;
        return this;
    }

    public CongasanBuilder WithC6marg(int newC6marg) {
        raw.C6marg = newC6marg;
        return this;
    }

    public CongasanBuilder WithC6medi(string newC6medi) {
        raw.C6medi = newC6medi;
        return this;
    }

    public CongasanBuilder WithC6ofer(string newC6ofer) {
        raw.C6ofer = newC6ofer;
        return this;
    }

    public CongasanBuilder WithC6segu(string newC6segu) {
        raw.C6segu = newC6segu;
        return this;
    }

    public CongasanBuilder WithC6bono(string newC6bono) {
        raw.C6bono = newC6bono;
        return this;
    }

    private static CongasanRaw GenerateRaw() {
        return new Faker<CongasanRaw>()
            .RuleFor(x => x.Code, f => f.Random.String(10, 'A', 'Z').ToUpper())
            .RuleFor(x => x.OriginCode, f => f.Random.String(10, 'A', 'Z').ToUpper())
            .RuleFor(x => x.OriginType, f => f.PickRandom<OriginType>().ToString())
            .RuleFor(x => x.C6fec1, f => f.Date.Future(1, DateTime.Now).ToString("yyyyMMdd"))
            .RuleFor(x => x.C6fec2, f => f.Date.Future(1, DateTime.Now.AddYears(1)).ToString("yyyyMMdd"))
            .RuleFor(x => x.C6gcdi, f => f.Random.Int(0, 99))
            .RuleFor(x => x.C6gcho, f => f.Random.Int(0, 99))
            .RuleFor(x => x.C6gcno, f => f.Random.Int(0, 99))
            .RuleFor(x => x.C6gcpo, f => f.Random.Decimal(0, 99))
            .RuleFor(x => x.C6gcim, f => f.Random.Decimal(0, 99))
            .RuleFor(x => x.C6marg, f => f.Random.Int(0, 99))
            .RuleFor(x => x.C6medi, f => f.Random.String(1,'A', 'Z'))
            .RuleFor(x => x.C6ofer, f => f.Random.String(1, 'A', 'Z'))
            .RuleFor(x => x.C6segu, f => f.Random.String(1, 'A', 'Z'))
            .RuleFor(x => x.C6bono, f => f.Random.String(1, 'A', 'Z'))
            .Generate();
    }

    public Congasan Build() {
        return new Faker<Congasan>()
            .RuleFor(x => x.Code, raw.Code)
            .RuleFor(x => x.OriginCode, raw.OriginCode)
            .RuleFor(x => x.OriginType, raw.OriginType)
            .RuleFor(x => x.C6fec1, raw.C6fec1)
            .RuleFor(x => x.C6fec2, raw.C6fec2)
            .RuleFor(x => x.C6gcdi, raw.C6gcdi)
            .RuleFor(x => x.C6gcho, raw.C6gcho)
            .RuleFor(x => x.C6gcno, raw.C6gcno)
            .RuleFor(x => x.C6gcpo, raw.C6gcpo)
            .RuleFor(x => x.C6gcim, raw.C6gcim)
            .RuleFor(x => x.C6marg, raw.C6marg)
            .RuleFor(x => x.C6medi, raw.C6medi)
            .RuleFor(x => x.C6ofer, raw.C6ofer)
            .RuleFor(x => x.C6segu, raw.C6segu)
            .RuleFor(x => x.C6bono, raw.C6bono)
            .Generate();
    }

    private class CongasanRaw {
        public string Code { get; set; } = string.Empty;
        public string OriginCode { get; set; } = string.Empty;
        public string OriginType { get; set; } = string.Empty;
        public string C6fec1 { get; set; } = string.Empty;
        public string C6fec2 { get; set; } = string.Empty;
        public int C6gcdi { get; set; }
        public int C6gcho { get; set; }
        public int C6gcno { get; set; }
        public decimal C6gcpo { get; set; }
        public decimal C6gcim { get; set; }
        public int C6marg { get; set; }
        public string C6medi { get; set; } = string.Empty;
        public string C6ofer { get; set; } = string.Empty;
        public string C6segu { get; set; } = string.Empty;
        public string C6bono { get; set; } = string.Empty;
    }
}
