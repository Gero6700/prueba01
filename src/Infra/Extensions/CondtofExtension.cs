namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class CondtofExtension {
    public static OfferAndSupplementConfigurationPax ToOfferAndSupplementConfigurationPax(this Condtof condtof) {
        return new OfferAndSupplementConfigurationPax {
            PaxOrder = int.Parse(condtof.O4tipa.Trim()[5..]),
            PaxType = condtof.O4tipa[..4].ToUpper() == "ADULT" ? PaxType.Adult : PaxType.Adult,
            Scope = condtof.O4tdto.ToUpper() == "E" ? ScopeType.Stay : ScopeType.Stay,
            AgeFrom = condtof.O4desd,
            AgeTo = condtof.O4has,
            Amount = condtof.O4dtos,
            AmountType = PaymentType.Percent
        };
    }
}
