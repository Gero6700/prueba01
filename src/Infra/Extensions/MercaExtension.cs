namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class MercaExtension {
    public static Market ToMarket(this Merca merca) {
        return new Market {
            Code = merca.Cod,
            Description = merca.Nom
        };
    }
    
}
