namespace Senator.As400.Cloud.Sync.Tests.Common.Builders; 

public class ConcabecBuilder {
    private ConcabecRaw raw = null!;

    public static ConcabecBuilder AConcabecBuilder() {
        return new ConcabecBuilder {
            raw = GenerateRaw()
        };
    }

    public ConcabecBuilder WithCoagen(int newCoagen) {
        raw.Coagen = newCoagen;
        return this;
    }

    public ConcabecBuilder WithCosucu(int newCosucu) {
        raw.Cosucu = newCosucu;
        return this;
    }

    public ConcabecBuilder WithCohote(int newCohote) {
        raw.Cohote = newCohote;
        return this;
    }

    public ConcabecBuilder WithCocont(string newCocont) {
        raw.Cocont = newCocont;
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

    public ConcabecBuilder WithCoagcl(int newCoagcl) {
        raw.Coagcl = newCoagcl;
        return this;
    }
    
    public ConcabecBuilder WithCosucl(int newCosucl) {
        raw.Cosucl = newCosucl;
        return this;
    }

    public ConcabecBuilder WithDinom2(string newDinom2) {
        raw.Dinom2 = newDinom2;
        return this;
    }

    public ConcabecBuilder WithCovers(int newCovers) {
        raw.Covers = newCovers;
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
    
    public Concabec Build() {
        return new Faker<Concabec>()
            .RuleFor(x => x.Coagen, raw.Coagen)
            .RuleFor(x => x.Cosucu, raw.Cosucu)
            .RuleFor(x => x.Cohote, raw.Cohote)
            .RuleFor(x => x.Cocont, raw.Cocont)
            .RuleFor(x => x.Cofec1, raw.Cofec1)
            .RuleFor(x => x.Cofec2, raw.Cofec2)
            .RuleFor(x => x.Codesc, raw.Codesc)
            .RuleFor(x => x.Dinom2, raw.Dinom2)
            .RuleFor(x => x.Cocoag, raw.Cocoag)
            .RuleFor(x => x.Coagcl, raw.Coagcl)
            .RuleFor(x => x.Cosucl, raw.Cosucl)
            .RuleFor(x => x.Coiva, raw.Coiva)
            .RuleFor(x => x.Cofext, raw.Cofext)
            .RuleFor(x => x.Covers, raw.Covers)
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
            .RuleFor(x => x.Coagen, f => f.Random.Int(10000, 99999))
            .RuleFor(x => x.Cosucu, f => f.Random.Int(1, 99))
            .RuleFor(x => x.Cohote, f => f.Random.Int(100, 9999))
            .RuleFor(x => x.Cocont, f => f.Random.AlphaNumeric(2).ToUpper())
            .RuleFor(x => x.Cofec1, f => (DateTime.Now.Year * 1000) + f.Random.Number(0, 365))
            .RuleFor(x => x.Cofec2, f => (DateTime.Now.Year + 1 * 1000) + f.Random.Number(0, 365))
            .RuleFor(x => x.Codesc, f => f.Random.String(10, 'A', 'Z').ToUpper())
            .RuleFor(x => x.Dinom2, f => f.Random.String(3, 'A', 'Z').ToUpper())
            .RuleFor(x => x.Cocoag, f => f.Random.Decimal())
            .RuleFor(x => x.Coagcl, f => f.Random.Int(10000, 99999))
            .RuleFor(x => x.Cosucl, f => f.Random.Int(1, 99))
            .RuleFor(x => x.Coiva, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cofext, f =>int.Parse(f.Date.Future().ToString("yyyyMMdd")))
            .RuleFor(x => x.Covers, f => f.Random.Int(0, 99))
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
        public int Coagen { get; set; }
        public int Cosucu { get; set; }
        public int Cohote { get; set; }
        public string Cocont { get; set; } = string.Empty;
        public int Cofec1 { get; set; }
        public int Cofec2 { get; set; }
        public string Codesc { get; set; } = string.Empty;
        public string Dinom2 { get; set; } = string.Empty;
        public decimal Cocoag { get; set; }
        public int Coagcl { get; set; }
        public int Cosucl { get; set; }
        public string Coiva { get; set; } = string.Empty;
        public int Cofext { get; set; }
        public int Covers { get; set; }
        public string Cobaco { get; set; } = string.Empty;
        public decimal Codpto { get; set; }
        public string Cofode { get; set; } = string.Empty;
        public int Coftop { get; set; }
        public string Codmerca { get; set; } = string.Empty;
        public decimal Cenimi { get; set; }
        public decimal Cenima { get; set; }
        public decimal Ceinmi { get; set; }
        public decimal Ceinma { get; set; }
        public decimal D4desd { get; set; }
        public decimal D4hast { get; set; }
        public long Idusuario { get; set; }
    }
}