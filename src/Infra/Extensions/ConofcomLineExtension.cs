namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ConofcomLineExtension {
    public static OfferAndSupplementGroupOfferAndSupplement ToOfferAndSupplementGroupOfferAndSupplement(this ConofcomLine conofcomLine) {
        return new OfferAndSupplementGroupOfferAndSupplement {
            OfferSupplementGroupCode = conofcomLine.Occin.ToString(),
            OfferSupplementCode = conofcomLine.OfferSupCode
        };
    }
}
