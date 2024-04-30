using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class RestregiExtension {
    public static Dtos.BookingCenter.Availability.Regime ToRegime(this Restregi restregi) {
        return new Dtos.BookingCenter.Availability.Regime
        {
            Code = restregi.Mrhab,
            Order = restregi.Roorde
        };
    }
}
