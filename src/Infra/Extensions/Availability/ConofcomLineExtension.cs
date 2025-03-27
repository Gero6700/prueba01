namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ConofcomLineExtension {
    public static OfferSupplementGroupRelationDto ToOfferAndSupplementGroupOfferAndSupplement(this ConofcomLine conofcomLine) {
        return new OfferSupplementGroupRelationDto {
            OfferSupplementGroupCode = conofcomLine.Occin.ToString(),
            OfferSupplementCode = conofcomLine.OfferSupCode
        };
    }
}
