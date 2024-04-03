using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class CondtofExtension {
    public static OfferAndSupplementConfigurationPax ToOfferAndSupplementConfigurationPax(this Condtof condtof) {
        var paxTypeString = condtof.O4tipa[..5].ToUpper();
        return new OfferAndSupplementConfigurationPax {
            PaxOrder = int.Parse(condtof.O4tipa.Trim()[5..]),
            PaxType = paxTypeString == "ADULT" && condtof.O4has < 18 ? PaxType.Teenager : paxTypeString == "ADULT" ? PaxType.Adult : paxTypeString == "NIÑOS" ? PaxType.Child : PaxType.Adult,
            Scope = condtof.O4tdto.ToUpper() == "E" ? ScopeType.Stay : condtof.O4tdto.ToUpper() == "S" ? ScopeType.Regime : ScopeType.Stay,
            AgeFrom = condtof.O4desd,
            AgeTo = condtof.O4has,
            Amount = condtof.O4dtos,
            AmountType = PaymentType.Percent,
            OfferAndSupplementConfigurationCode = condtof.OfferAndSupplementCode,
            Code = condtof.Code
        };
    }
}
