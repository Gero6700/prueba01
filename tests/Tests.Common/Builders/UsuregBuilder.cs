namespace Senator.As400.Cloud.Sync.Tests.Common.Builders;
public class UsuregBuilder {
    private UsuregRaw raw = null!;

    public static UsuregBuilder AnUsuregBuilder() {
        return new UsuregBuilder { 
            raw = GenerateRaw() 
        };
    }

    public UsuregBuilder WithIdUsuario(long idUsuario) {
        raw.IdUsuario = idUsuario;
        return this;
    }

    public UsuregBuilder WithUsuario(string usuario) {
        raw.Usuario = usuario;
        return this;
    }

    public UsuregBuilder WithClave(string clave) {
        raw.Clave = clave;
        return this;
    }

    public UsuregBuilder WithNombreComercial(string nombreComercial) {
        raw.NombreComercial = nombreComercial;
        return this;
    }

    public UsuregBuilder WithAgGroup(char agGroup) {
        raw.AgGroup = agGroup;
        return this;
    }

    public Usureg Build() {
        return new Faker<Usureg>()
            .RuleFor(x => x.IdUsuario, raw.IdUsuario)
            .RuleFor(x => x.Usuario, raw.Usuario)
            .RuleFor(x => x.Clave, raw.Clave)
            .RuleFor(x => x.NombreComercial, raw.NombreComercial)
            .RuleFor(x => x.AgGroup, raw.AgGroup)
            .Generate();
    }

    private static UsuregRaw GenerateRaw() {
        return new Faker<UsuregRaw>()
            .RuleFor(x => x.IdUsuario, f => f.Random.Long())
            .RuleFor(x => x.Usuario, f => f.Internet.UserName())
            .RuleFor(x => x.Clave, f => f.Internet.Password())
            .RuleFor(x => x.NombreComercial, f => f.Company.CompanyName())
            .RuleFor(x => x.AgGroup, f => f.Random.Char('A','Z'))
            .Generate();
    }

    private class UsuregRaw {
        public long IdUsuario { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
        public string NombreComercial { get; set; } = string.Empty;
        public char AgGroup { get; set; }
    }
}

