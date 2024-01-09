using Bogus;
using Senator.As400.Cloud.Sync.Application.Dtos.As400;

namespace Senator.As400.Cloud.Sync.Tests.Common.Builders; 

public class ConcabecBuilder {
    private ConcabecRaw raw = null!;

    public static ConcabecBuilder AnConcabecBuilder() {
        return new ConcabecBuilder {
            raw = GenerateRaw()
        };
    }

    public ConcabecBuilder WithCoagen(int coagen) {
        raw.Coagen = coagen;
        return this;
    }

    public ConcabecBuilder WithCosucu(int cosucu) {
        raw.Cosucu = cosucu;
        return this;
    }

    public ConcabecBuilder WithCohote(int cohote) {
        raw.Cohote = cohote;
        return this;
    }

    public ConcabecBuilder WithCocont(string cocont) {
        raw.Cocont = cocont;
        return this;
    }

    public ConcabecBuilder WithCofec1(int cofec1) {
        raw.Cofec1 = cofec1;
        return this;
    }

    public ConcabecBuilder WithCofec2(int cofec2) {
        raw.Cofec2 = cofec2;
        return this;
    }

    public ConcabecBuilder WithCoagcl(int coagcl) {
        raw.Coagcl = coagcl;
        return this;
    }
    
    public ConcabecBuilder WithCosucl(int cosucl) {
        raw.Cosucl = cosucl;
        return this;
    }

    public ConcabecBuilder WithComone(int comone) {
        raw.Comone = comone;
        return this;
    }

    public ConcabecBuilder WithCovers(int covers) {
        raw.Covers = covers;
        return this;
    }



    public Concabec Build() {
        return new Faker<Concabec>()
            .RuleFor(x => x.Coagen, f => raw.Coagen)
            .RuleFor(x => x.Cosucu, f => raw.Cosucu)
            .RuleFor(x => x.Cohote, f => raw.Cohote)
            .RuleFor(x => x.Cocont, f => raw.Cocont)
            .RuleFor(x => x.Cofec1, f => raw.Cofec1)
            .RuleFor(x => x.Cofec2, f => raw.Cofec2)
            .RuleFor(x => x.Codesc, f => raw.Codesc)
            .RuleFor(x => x.Cohf, f => raw.Cohf)
            .RuleFor(x => x.Corece, f => raw.Corece)
            .RuleFor(x => x.Cotran, f => raw.Cotran)
            .RuleFor(x => x.Comone, f => raw.Comone)
            .RuleFor(x => x.Cotrai, f => raw.Cotrai)
            .RuleFor(x => x.Cocoag, f => raw.Cocoag)
            .RuleFor(x => x.Coagcl, f => raw.Coagcl)
            .RuleFor(x => x.Cosucl, f => raw.Cosucl)
            .RuleFor(x => x.Cococl, f => raw.Cococl)
            .RuleFor(x => x.Coiva, f => raw.Coiva)
            .RuleFor(x => x.Cocore, f => raw.Cocore)
            .RuleFor(x => x.Cofact, f => raw.Cofact)
            .RuleFor(x => x.Cofpag, f => raw.Cofpag)
            .RuleFor(x => x.Copfcc, f => raw.Copfcc)
            .RuleFor(x => x.Cocuga, f => raw.Cocuga)
            .RuleFor(x => x.Coencu, f => raw.Coencu)
            .RuleFor(x => x.Coenct, f => raw.Coenct)
            .RuleFor(x => x.Coencd, f => raw.Coencd)
            .RuleFor(x => x.Coidio, f => raw.Coidio)
            .RuleFor(x => x.Coconf, f => raw.Coconf)
            .RuleFor(x => x.Cogcno, f => raw.Cogcno)
            .RuleFor(x => x.Cogcpo, f => raw.Cogcpo)
            .RuleFor(x => x.Cogcim, f => raw.Cogcim)
            .RuleFor(x => x.Cogcto, f => raw.Cogcto)
            .RuleFor(x => x.Cogcho, f => raw.Cogcho)
            .RuleFor(x => x.Coest, f => raw.Coest)
            .RuleFor(x => x.Copgm, f => raw.Copgm)
            .RuleFor(x => x.Cocarp, f => raw.Cocarp)
            .RuleFor(x => x.Cosubc, f => raw.Cosubc)
            .RuleFor(x => x.Coasig, f => raw.Coasig)
            .RuleFor(x => x.Cofext, f => raw.Cofext)
            .RuleFor(x => x.Covers, f => raw.Covers)
            .RuleFor(x => x.Cobaco, f => raw.Cobaco)
            .RuleFor(x => x.Cobacc, f => raw.Cobacc)
            .RuleFor(x => x.Cocose, f => raw.Cocose)
            .RuleFor(x => x.Cotemp, f => raw.Cotemp)
            .RuleFor(x => x.Cocpor, f => raw.Cocpor)
            .RuleFor(x => x.Cocage, f => raw.Cocage)
            .RuleFor(x => x.Cocsuc, f => raw.Cocsuc)
            .RuleFor(x => x.Cocagc, f => raw.Cocagc)
            .RuleFor(x => x.Cocscl, f => raw.Cocscl)
            .RuleFor(x => x.Cochot, f => raw.Cochot)
            .RuleFor(x => x.Coccto, f => raw.Coccto)
            .RuleFor(x => x.Cocver, f => raw.Cocver)
            .RuleFor(x => x.Cocfe1, f => raw.Cocfe1)
            .RuleFor(x => x.Codde1, f => raw.Codde1)
            .RuleFor(x => x.Codco1, f => raw.Codco1)
            .RuleFor(x => x.Codde2, f => raw.Codde2)
            .RuleFor(x => x.Codco2, f => raw.Codco2)
            .RuleFor(x => x.Copalo, f => raw.Copalo)
            .RuleFor(x => x.Codpto, f => raw.Codpto)
            .RuleFor(x => x.Cofode, f => raw.Cofode)
            .RuleFor(x => x.Coftop, f => raw.Coftop)
            .RuleFor(x => x.Rrnmod, f => raw.Rrnmod)
            .RuleFor(x => x.Estadmod, f => raw.Estadmod)
            .RuleFor(x => x.Fechamod, f => raw.Fechamod)
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
            .RuleFor(x => x.Codesc, (f, a) => string.Concat("CONTRACT ", a.Cocont, " ", a.Cofec1.ToString().AsSpan(0, 4)))
            .RuleFor(x => x.Cohf, f => f.Random.Double())
            .RuleFor(x => x.Corece, f => f.Random.Double())
            .RuleFor(x => x.Cotran, f => f.Random.Double())
            .RuleFor(x => x.Comone, f => f.Random.Int(2))
            .RuleFor(x => x.Cotrai, f => f.Random.Double())
            .RuleFor(x => x.Cocoag, f => f.Random.Double())
            .RuleFor(x => x.Coagcl, f => f.Random.Int(10000, 99999))
            .RuleFor(x => x.Cosucl, f => f.Random.Int(1, 99))
            .RuleFor(x => x.Cococl, f => f.Random.Double())
            .RuleFor(x => x.Coiva, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cocore, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cofact, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cofpag, f => f.Random.String(3).ToUpper())
            .RuleFor(x => x.Copfcc, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cocuga, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coencu, f => f.Random.Double())
            .RuleFor(x => x.Coenct, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coencd, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coidio, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coconf, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Cogcno, f => f.Random.Int(0,9))
            .RuleFor(x => x.Cogcpo, f => f.Random.Double())
            .RuleFor(x => x.Cogcim, f => f.Random.Double())
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
            .RuleFor(x => x.Cocpor, f => f.Random.Double())
            .RuleFor(x => x.Cocage, (f, x) => x.Coagen)
            .RuleFor(x => x.Cocsuc, (f, x) => x.Cosucu)
            .RuleFor(x => x.Cocagc, (f, x) => x.Coagcl)
            .RuleFor(x => x.Cocscl, (f, x) => x.Cosucl)
            .RuleFor(x => x.Cochot, (f, x) => x.Cohote)
            .RuleFor(x => x.Coccto, (f, x) => x.Cocont)
            .RuleFor(x => x.Cocver, (f, x) => x.Covers)
            .RuleFor(x => x.Cocfe1, (f,x) => x.Cofec1)
            .RuleFor(x => x.Codde1, f => f.Random.Double())
            .RuleFor(x => x.Codco1, f => f.Random.Word())
            .RuleFor(x => x.Codde2, f => f.Random.Double())
            .RuleFor(x => x.Codco2, f => f.Random.Word())
            .RuleFor(x => x.Copalo, f => f.Random.Double())
            .RuleFor(x => x.Codpto, f => f.Random.Double())
            .RuleFor(x => x.Cofode, f => f.Random.Char('A', 'Z').ToString().ToUpper())
            .RuleFor(x => x.Coftop, f => f.Random.Int(0, 999999))
            .RuleFor(x => x.Rrnmod, f => f.Random.Long(0, 9999999999))
            .RuleFor(x => x.Estadmod, f => f.PickRandom('A','B','M').ToString())
            .RuleFor(x => x.Fechamod, f => f.Date.Past())
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
        public double Cohf { get; set; }
        public double Corece { get; set; }
        public double Cotran { get; set; }
        public int Comone { get; set; }
        public double Cotrai { get; set; }
        public double Cocoag { get; set; }
        public int Coagcl { get; set; }
        public int Cosucl { get; set; }
        public double Cococl { get; set; }
        public string Coiva { get; set; } = string.Empty;
        public string Cocore { get; set; } = string.Empty;
        public string Cofact { get; set; } = string.Empty;
        public string Cofpag { get; set; } = string.Empty;
        public string Copfcc { get; set; } = string.Empty;
        public string Cocuga { get; set; } = string.Empty;
        public double Coencu { get; set; }
        public string Coenct { get; set; } = string.Empty;
        public string Coencd { get; set; } = string.Empty;
        public string Coidio { get; set; } = string.Empty;
        public string Coconf { get; set; } = string.Empty;
        public int Cogcno { get; set; }
        public double Cogcpo { get; set; }
        public double Cogcim { get; set; }
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
        public double Cocpor { get; set; }
        public int Cocage { get; set; }
        public int Cocsuc { get; set; }
        public int Cocagc { get; set; }
        public int Cocscl { get; set; }
        public int Cochot { get; set; }
        public string Coccto { get; set; } = string.Empty;
        public int Cocver { get; set; }
        public int Cocfe1 { get; set; }
        public double Codde1 { get; set; }
        public string Codco1 { get; set; } = string.Empty;
        public double Codde2 { get; set; }
        public string Codco2 { get; set; } = string.Empty;
        public double Copalo { get; set; }
        public double Codpto { get; set; }
        public string Cofode { get; set; } = string.Empty;
        public int Coftop { get; set; }
        public long Rrnmod { get; set; }
        public string Estadmod { get; set; } = string.Empty;
        public DateTime Fechamod { get; set; }
    }

}