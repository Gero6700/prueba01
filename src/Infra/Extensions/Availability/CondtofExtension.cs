using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class CondtofExtension {
    public static OfferSupplementConfigurationPaxDto ToOfferAndSupplementConfigurationPax(this Condtof condtof) {
        var paxTypeString = condtof.O4tipa[..5].ToUpper();
        return new OfferSupplementConfigurationPaxDto {
            Code = condtof.Code,
            PaxOrder = int.Parse(condtof.O4tipa.Trim()[5..]),
            PaxType = paxTypeString == "NIÑOS" ? 
                PaxType.Child.ToString() : 
                paxTypeString == "ADULT" && condtof.O4has > 0 && condtof.O4has < 18 ? 
                    PaxType.Teenager.ToString() : 
                    PaxType.Adult.ToString(),
            Scope = condtof.O4tdto.ToUpper() == "E" ? ScopeType.Stay.ToString() : condtof.O4tdto.ToUpper() == "S" ? ScopeType.Meal.ToString() : ScopeType.Stay.ToString(),
            AgeFrom = condtof.O4desd == 0 ? null : condtof.O4desd,
            AgeTo = condtof.O4has == 0 ? null : condtof.O4has,
            Amount = condtof.O4dtos,
            AmountType = TypeOfPayment.Percent.ToString(),
            OfferSupplementCode = condtof.Codeof
        };
    }
}
