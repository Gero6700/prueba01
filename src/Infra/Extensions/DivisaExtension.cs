namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class DivisaExtension
{
    public static Currency ToCurrency(this Divisa divisa) {
        return new Currency {
            IsoCode = divisa.Dinom2,
            Description = divisa.Dinomb,
            Symbol = divisa.Disimb
        };
    }
}
