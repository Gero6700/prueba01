using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class MercaExtension {
    public static MarketDto ToMarket(this Merca merca) {
        return new MarketDto {
            Code = merca.Cod,
            Description = merca.Nom
        };
    }

}
