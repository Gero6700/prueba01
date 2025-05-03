namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class ReszoimExtension {
    public static StaticTax ToTax(this Reszoim reszoim) {
        return new StaticTax {
            Code = reszoim.Zocod,
            Description = reszoim.Zotext,
            Amount = reszoim.Zoporc,
            Order = reszoim.Zoorde,
            AppliesToTaxableBase = reszoim.Zosobr == "B"
        };
    }
}
