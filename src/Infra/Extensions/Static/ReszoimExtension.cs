namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Static;
public static class ReszoimExtension {
    public static Tax ToTax(this Reszoim reszoim) {
        return new Tax {
            Code = reszoim.Code,
            Description = reszoim.Zotext,
            Amount = reszoim.Zoporc,
            AmountType = TypeOfPayment.Percent,
            Type = TaxType.Vat
        };
    }
}
