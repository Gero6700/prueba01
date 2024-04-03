using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class RestregiExtension {
    public static Regime ToRegime(this Restregi restregi) {
        return new Regime {
            Code = restregi.Mrhab,
            Order = restregi.Roorde
        };
    }
}
