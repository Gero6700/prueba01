namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class MarcaComercialExtension {
    public static Category ToCategory(this MarcaComercial marcaComercial) {
        return new Category {
            Code = marcaComercial.Id.ToString(),
            Translations = [
                new() {
                    Name = marcaComercial.Nombre,
                    LanguageIsoCode = "es-ES"
                }
            ]
        };
    }
}
