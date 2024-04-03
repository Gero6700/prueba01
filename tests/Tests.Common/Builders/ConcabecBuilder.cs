namespace Senator.As400.Cloud.Sync.Tests.Common.Builders; 

public class ConcabecBuilder {
    private ConcabecRaw raw = null!;

    public static ConcabecBuilder AConcabecBuilder() {
        return new ConcabecBuilder {
            raw = GenerateRaw()
        };
    }

    public ConcabecBuilder WithCohote(int newCohote) {
        raw.Cohote = newCohote;
        return this;
    }

    public ConcabecBuilder WithCofec1(int newCofec1) {
        raw.Cofec1 = newCofec1;
        return this;
    }

    public ConcabecBuilder WithCodesc(string newCodesc) {
        raw.Codesc = newCodesc;
        return this;
    }

    public ConcabecBuilder WithCofec2(int newCofec2) {
        raw.Cofec2 = newCofec2;
        return this;
    }

    public ConcabecBuilder WithDinom2(string newDinom2) {
        raw.Dinom2 = newDinom2;
        return this;
    }

    public ConcabecBuilder WithCodmerca(string newCodmerca) {
        raw.Codmerca = newCodmerca;
        return this;
    }

    public ConcabecBuilder WithCeinma(decimal newCeinma) {
        raw.Ceinma = newCeinma;
        return this;
    }

    public ConcabecBuilder WithCenimi(decimal newCenimi) {
        raw.Cenimi = newCenimi;
        return this;
    }

    public ConcabecBuilder WithCenima(decimal newCenima) {
        raw.Cenima = newCenima;
        return this;
    }

    public ConcabecBuilder WithD4desd(decimal newD4desd) {
        raw.D4desd = newD4desd;
        return this;
    }

    public ConcabecBuilder WithD4hast(decimal newD4hast) {
        raw.D4hast = newD4hast;
        return this;
    }

    public ConcabecBuilder WithCocoag(decimal newCocoag) {
        raw.Cocoag = newCocoag;
        return this;
    }
    
    public ConcabecBuilder WithIdusuario(long newIdusuario) {
        raw.Idusuario = newIdusuario;
        return this;
    }
    
    public ConcabecBuilder WithCofext(int newCofext) {
        raw.Cofext = newCofext;
        return this;
    }
    
    public ConcabecBuilder WithCofode(string newCofode) {
        raw.Cofode = newCofode;
        return this;
    }
    
    public ConcabecBuilder WithCoftop(int newCoftop) {
        raw.Coftop = newCoftop;
        return this;
    }
    
    public ConcabecBuilder WithCodpto(decimal newCodpto) {
        raw.Codpto = newCodpto;
        return this;
    }
    
    public ConcabecBuilder WithCoiva(string newCoiva) {
        raw.Coiva = newCoiva;
        return this;
    }

    public ConcabecBuilder WithCobaco(string newCobaco) {
        raw.Cobaco = newCobaco;
        return this;
    }

    public ConcabecBuilder WithContractCode(string newContractCode) {
        raw.ContractCode = newContractCode;
        return this;
    }

    public ConcabecBuilder WithContractClientCode(string newContractClientCode) {
        raw.ContractClientCode = newContractClientCode;
        return this;
    }
    
    public Concabec Build() {
        return new Faker<Concabec>()
            .RuleFor(x => x.ContractCode, raw.ContractCode)
            .RuleFor(x => x.ContractClientCode, raw.ContractClientCode)
            .RuleFor(x => x.Cohote, raw.Cohote)
            .RuleFor(x => x.Cofec1, raw.Cofec1)
            .RuleFor(x => x.Cofec2, raw.Cofec2)
            .RuleFor(x => x.Codesc, raw.Codesc)
            .RuleFor(x => x.Dinom2, raw.Dinom2)
            .RuleFor(x => x.Cocoag, raw.Cocoag)
            .RuleFor(x => x.Coiva, raw.Coiva)
            .RuleFor(x => x.Cofext, raw.Cofext)
            .RuleFor(x => x.Cobaco, raw.Cobaco)
            .RuleFor(x => x.Codpto, raw.Codpto)
            .RuleFor(x => x.Cofode, raw.Cofode)
            .RuleFor(x => x.Coftop, raw.Coftop)
            .RuleFor(x => x.Codmerca, raw.Codmerca)
            .RuleFor(x => x.Cenimi, raw.Cenimi)
            .RuleFor(x => x.Cenima, raw.Cenima)
            .RuleFor(x => x.Ceinmi, raw.Ceinmi)
            .RuleFor(x => x.Ceinma, raw.Ceinma)
            .RuleFor(x => x.D4desd, raw.D4desd)
            .RuleFor(x => x.D4hast, raw.D4hast)
            .RuleFor(x => x.Idusuario, raw.Idusuario)
            .Generate();
    }

    private static ConcabecRaw GenerateRaw() {
        return new Faker<ConcabecRaw>()
            .RuleFor(x => x.ContractCode, f => f.Random.String(10, 'A', 'Z').ToUpper())
            .RuleFor(x => x.ContractClientCode, f => f.Random.String(10, 'A', 'Z').ToUpper())
            .RuleFor(x => x.Cohote, f => f.Random.Int(100, 9999))
            .RuleFor(x => x.Cofec1, f => (DateTime.Now.Year * 1000) + f.Random.Number(1, 365))
            .RuleFor(x => x.Cofec2, f => (DateTime.Now.Year + 1 * 1000) + f.Random.Number(1, 365))
            .RuleFor(x => x.Codesc, f => f.Random.String(10, 'A', 'Z').ToUpper())
            .RuleFor(x => x.Dinom2, f => f.Random.String(3, 'A', 'Z').ToUpper())
            .RuleFor(x => x.Cocoag, f => f.Random.Decimal())
            .RuleFor(x => x.Coiva, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cofext, f =>int.Parse(f.Date.Future().ToString("yyyyMMdd")))
            .RuleFor(x => x.Cobaco, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Codpto, f => f.Random.Decimal())
            .RuleFor(x => x.Cofode, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coftop, f => f.Random.Int(0, 999999))
            .RuleFor(x => x.Codmerca, f => f.Random.String(3, 'A', 'Z').ToUpper())
            .RuleFor(x => x.D4desd, f => f.Random.Int(13, 15))
            .RuleFor(x => x.D4hast, (_, x) => x.D4desd + 2.99m)
            .RuleFor(x => x.Cenima, (_, x) => x.D4desd - 0.01m)
            .RuleFor(x => x.Cenimi, (_, x) => x.Cenima - 9.99m)
            .RuleFor(x => x.Ceinma, (_, x) => x.Cenimi - 0.01m)
            .RuleFor(x => x.Ceinmi, f => f.Random.Decimal(0,0))
            .RuleFor(x => x.Idusuario, f => f.Random.Long(1000000000, 999999999999))
            .Generate();
    }

    private class ConcabecRaw {
        public string ContractCode { get; set; } = string.Empty;
        public string ContractClientCode { get; set; } = string.Empty;
        public int Cohote { get; set; }
        public int Cofec1 { get; set; }
        public int Cofec2 { get; set; }
        public string Codesc { get; set; } = string.Empty;
        public decimal Cocoag { get; set; }
        public string Coiva { get; set; } = string.Empty;
        public int Cofext { get; set; }
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
        //contgral.divisa
        public string Dinom2 { get; set; } = string.Empty;
    }
}