namespace Senator.As400.Cloud.Sync.Tests.Common.Builders; 

public class ConcabecBuilder {
    private ConcabecRaw raw = null!;

    public static ConcabecBuilder AnConcabecBuilder() {
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

    public ConcabecBuilder WithComone(int newComone) {
        raw.Comone = newComone;
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
    
    public Concabec Build() {
        return new Faker<Concabec>()
            .RuleFor(x => x.Coagen, raw.Coagen)
            .RuleFor(x => x.Cosucu, raw.Cosucu)
            .RuleFor(x => x.Cohote, raw.Cohote)
            .RuleFor(x => x.Cocont, raw.Cocont)
            .RuleFor(x => x.Cofec1, raw.Cofec1)
            .RuleFor(x => x.Cofec2, raw.Cofec2)
            .RuleFor(x => x.Codesc, raw.Codesc)
            .RuleFor(x => x.Cohf, raw.Cohf)
            .RuleFor(x => x.Corece, raw.Corece)
            .RuleFor(x => x.Cotran, raw.Cotran)
            .RuleFor(x => x.Comone, raw.Comone)
            .RuleFor(x => x.Cotrai, raw.Cotrai)
            .RuleFor(x => x.Cocoag, raw.Cocoag)
            .RuleFor(x => x.Coagcl, raw.Coagcl)
            .RuleFor(x => x.Cosucl, raw.Cosucl)
            .RuleFor(x => x.Cococl, raw.Cococl)
            .RuleFor(x => x.Coiva, raw.Coiva)
            .RuleFor(x => x.Cocore, raw.Cocore)
            .RuleFor(x => x.Cofact, raw.Cofact)
            .RuleFor(x => x.Cofpag, raw.Cofpag)
            .RuleFor(x => x.Copfcc, raw.Copfcc)
            .RuleFor(x => x.Cocuga, raw.Cocuga)
            .RuleFor(x => x.Coencu, raw.Coencu)
            .RuleFor(x => x.Coenct, raw.Coenct)
            .RuleFor(x => x.Coencd, raw.Coencd)
            .RuleFor(x => x.Coidio, raw.Coidio)
            .RuleFor(x => x.Coconf, raw.Coconf)
            .RuleFor(x => x.Cogcno, raw.Cogcno)
            .RuleFor(x => x.Cogcpo, raw.Cogcpo)
            .RuleFor(x => x.Cogcim, raw.Cogcim)
            .RuleFor(x => x.Cogcto, raw.Cogcto)
            .RuleFor(x => x.Cogcho, raw.Cogcho)
            .RuleFor(x => x.Coest, raw.Coest)
            .RuleFor(x => x.Copgm, raw.Copgm)
            .RuleFor(x => x.Cocarp, raw.Cocarp)
            .RuleFor(x => x.Cosubc, raw.Cosubc)
            .RuleFor(x => x.Coasig, raw.Coasig)
            .RuleFor(x => x.Cofext, raw.Cofext)
            .RuleFor(x => x.Covers, raw.Covers)
            .RuleFor(x => x.Cobaco, raw.Cobaco)
            .RuleFor(x => x.Cobacc, raw.Cobacc)
            .RuleFor(x => x.Cocose, raw.Cocose)
            .RuleFor(x => x.Cotemp, raw.Cotemp)
            .RuleFor(x => x.Cocpor, raw.Cocpor)
            .RuleFor(x => x.Cocage, raw.Cocage)
            .RuleFor(x => x.Cocsuc, raw.Cocsuc)
            .RuleFor(x => x.Cocagc, raw.Cocagc)
            .RuleFor(x => x.Cocscl, raw.Cocscl)
            .RuleFor(x => x.Cochot, raw.Cochot)
            .RuleFor(x => x.Coccto, raw.Coccto)
            .RuleFor(x => x.Cocver, raw.Cocver)
            .RuleFor(x => x.Cocfe1, raw.Cocfe1)
            .RuleFor(x => x.Codde1, raw.Codde1)
            .RuleFor(x => x.Codco1, raw.Codco1)
            .RuleFor(x => x.Codde2, raw.Codde2)
            .RuleFor(x => x.Codco2, raw.Codco2)
            .RuleFor(x => x.Copalo, raw.Copalo)
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
            .RuleFor(x => x.Codesc,
                (_, a) => string.Concat("CONTRACT ", a.Cocont, " ", a.Cofec1.ToString().AsSpan(0, 4)))
            .RuleFor(x => x.Cohf, f => f.Random.Decimal())
            .RuleFor(x => x.Corece, f => f.Random.Decimal())
            .RuleFor(x => x.Cotran, f => f.Random.Decimal())
            .RuleFor(x => x.Comone, f => f.Random.Int(2))
            .RuleFor(x => x.Cotrai, f => f.Random.Decimal())
            .RuleFor(x => x.Cocoag, f => f.Random.Decimal())
            .RuleFor(x => x.Coagcl, f => f.Random.Int(10000, 99999))
            .RuleFor(x => x.Cosucl, f => f.Random.Int(1, 99))
            .RuleFor(x => x.Cococl, f => f.Random.Decimal())
            .RuleFor(x => x.Coiva, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cocore, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cofact, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cofpag, f => f.Random.String(3).ToUpper())
            .RuleFor(x => x.Copfcc, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cocuga, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coencu, f => f.Random.Decimal())
            .RuleFor(x => x.Coenct, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coencd, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coidio, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coconf, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cogcno, f => f.Random.Int(0,9))
            .RuleFor(x => x.Cogcpo, f => f.Random.Decimal())
            .RuleFor(x => x.Cogcim, f => f.Random.Decimal())
            .RuleFor(x => x.Cogcto, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cogcho, f => f.Random.Int(10000, 99999))
            .RuleFor(x => x.Coest, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Copgm, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cocarp, f => f.Random.Int(10000, 99999))
            .RuleFor(x => x.Cosubc, f => f.Random.Int(10, 99))
            .RuleFor(x => x.Coasig, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cofext, f =>int.Parse(f.Date.Future().ToString("yyyyMMdd")))
            .RuleFor(x => x.Covers, f => f.Random.Int(0, 99))
            .RuleFor(x => x.Cobaco, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cobacc, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cocose, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cotemp, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cocpor, f => f.Random.Decimal())
            .RuleFor(x => x.Cocage, (_, x) => x.Coagen)
            .RuleFor(x => x.Cocsuc, (_, x) => x.Cosucu)
            .RuleFor(x => x.Cocagc, (_, x) => x.Coagcl)
            .RuleFor(x => x.Cocscl, (_, x) => x.Cosucl)
            .RuleFor(x => x.Cochot, (_, x) => x.Cohote)
            .RuleFor(x => x.Coccto, (_, x) => x.Cocont)
            .RuleFor(x => x.Cocver, (_, x) => x.Covers)
            .RuleFor(x => x.Cocfe1, (_, x) => x.Cofec1)
            .RuleFor(x => x.Codde1, f => f.Random.Decimal())
            .RuleFor(x => x.Codco1, f => f.Random.Word())
            .RuleFor(x => x.Codde2, f => f.Random.Decimal())
            .RuleFor(x => x.Codco2, f => f.Random.Word())
            .RuleFor(x => x.Copalo, f => f.Random.Decimal())
            .RuleFor(x => x.Codpto, f => f.Random.Decimal())
            .RuleFor(x => x.Cofode, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coftop, f => f.Random.Int(0, 999999))
            .RuleFor(x => x.Codmerca, f => f.Random.String(3).ToUpper())
            .RuleFor(x => x.D4desd, f => f.Random.Int(13, 15))
            .RuleFor(x => x.D4hast, (_, x) => x.D4desd + 2.99m)
            .RuleFor(x => x.Cenima, (_, x) => x.D4desd - 0.01m)
            .RuleFor(x => x.Cenimi, (_, x) => x.Cenima - 9.99m)
            .RuleFor(x => x.Ceinma, (_, x) => x.Cenimi - 0.01m)
            .RuleFor(x => x.Ceinmi, f => f.Random.Decimal(0,0))
            .RuleFor(x => x.Idusuario, f => f.Random.Long(1000000000, 999999999999))

            //.RuleFor(x => x.Rrnmod, f => f.Random.Long(0, 9999999999))
            //.RuleFor(x => x.Estadmod, f => f.PickRandom('A','B','M').ToString())
            //.RuleFor(x => x.Fechamod, f => f.Date.Past())
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
        public decimal Cohf { get; set; }
        public decimal Corece { get; set; }
        public decimal Cotran { get; set; }
        public int Comone { get; set; }
        public decimal Cotrai { get; set; }
        public decimal Cocoag { get; set; }
        public int Coagcl { get; set; }
        public int Cosucl { get; set; }
        public decimal Cococl { get; set; }
        public string Coiva { get; set; } = string.Empty;
        public string Cocore { get; set; } = string.Empty;
        public string Cofact { get; set; } = string.Empty;
        public string Cofpag { get; set; } = string.Empty;
        public string Copfcc { get; set; } = string.Empty;
        public string Cocuga { get; set; } = string.Empty;
        public decimal Coencu { get; set; }
        public string Coenct { get; set; } = string.Empty;
        public string Coencd { get; set; } = string.Empty;
        public string Coidio { get; set; } = string.Empty;
        public string Coconf { get; set; } = string.Empty;
        public int Cogcno { get; set; }
        public decimal Cogcpo { get; set; }
        public decimal Cogcim { get; set; }
        public string Cogcto { get; set; } = string.Empty;
        public int Cogcho { get; set; }
        public string Coest { get; set; } = string.Empty;
        public string Copgm { get; set; } = string.Empty;
        public int Cocarp { get; set; }
        public int Cosubc { get; set; }
        public string Coasig { get; set; } = string.Empty;
        public int Cofext { get; set; }
        public int Covers { get; set; }
        public string Cobaco { get; set; } = string.Empty;
        public string Cobacc { get; set; } = string.Empty;
        public string Cocose { get; set; } = string.Empty;
        public string Cotemp { get; set; } = string.Empty;
        public decimal Cocpor { get; set; }
        public int Cocage { get; set; }
        public int Cocsuc { get; set; }
        public int Cocagc { get; set; }
        public int Cocscl { get; set; }
        public int Cochot { get; set; }
        public string Coccto { get; set; } = string.Empty;
        public int Cocver { get; set; }
        public int Cocfe1 { get; set; }
        public decimal Codde1 { get; set; }
        public string Codco1 { get; set; } = string.Empty;
        public decimal Codde2 { get; set; }
        public string Codco2 { get; set; } = string.Empty;
        public decimal Copalo { get; set; }
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