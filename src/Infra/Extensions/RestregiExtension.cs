namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class RestregiExtension {
    public static Regime ToRegime(this Restregi restregi) {
        return new Regime {
            Code = restregi.Mrhab,
            Order = restregi.Roorde
        };
    }
}
