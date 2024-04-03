using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class MercaExtension {
    public static Market ToMarket(this Merca merca) {
        return new Market {
            Code = merca.Cod,
            Description = merca.Nom
        };
    }

}
