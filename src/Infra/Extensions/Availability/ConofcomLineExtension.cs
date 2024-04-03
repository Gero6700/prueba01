using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ConofcomLineExtension {
    public static OfferAndSupplementGroupOfferAndSupplement ToOfferAndSupplementGroupOfferAndSupplement(this ConofcomLine conofcomLine) {
        return new OfferAndSupplementGroupOfferAndSupplement {
            OfferSupplementGroupCode = conofcomLine.Occin.ToString(),
            OfferSupplementCode = conofcomLine.OfferSupCode
        };
    }
}
