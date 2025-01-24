namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class CondtofExtension {
    public static OfferSupplementConfigurationPaxDto ToOfferAndSupplementConfigurationPax(this Condtof condtof) {
        var paxTypeString = condtof.O4tipa[..5].ToUpper();
        return new OfferSupplementConfigurationPaxDto {
            Code = condtof.Code,
            PaxOrder = int.Parse(condtof.O4tipa.Trim()[5..]),
            PaxType = paxTypeString == "ADULT" && condtof.O4has < 18 ? PaxType.Teenager : paxTypeString == "ADULT" ? PaxType.Adult : paxTypeString == "NIÑOS" ? PaxType.Child : PaxType.Adult,
            Scope = condtof.O4tdto.ToUpper() == "E" ? ScopeType.Stay : condtof.O4tdto.ToUpper() == "S" ? ScopeType.Regime : ScopeType.Stay,
            AgeFrom = condtof.O4desd == 0 ? null : condtof.O4desd,
            AgeTo = condtof.O4has == 0 ? null : condtof.O4has,
            Amount = condtof.O4dtos,
            AmountType = TypeOfPayment.Percent,
            OfferSupplementCode = condtof.OfferAndSupplementCode
        };
    }
}
