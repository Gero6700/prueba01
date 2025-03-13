namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class CondtosExtension {
    public static PeriodPricingPaxDto ToPeriodPricingPax(this Condtos condtos) {
        var paxTypeString = condtos.D4tipa[..5].ToUpper();
        return new PeriodPricingPaxDto {
            PaxOrder = int.Parse(condtos.D4tipa.Trim()[5..]),
            PaxType = paxTypeString == "NIÑOS" ? PaxType.Child.ToString() : paxTypeString == "ADULT" && condtos.D4has < 18 ? PaxType.Teenager.ToString() : PaxType.Adult.ToString(),
            Scope = condtos.D4tdto.ToUpper() == "E" ? ScopeType.Stay.ToString() : condtos.D4tdto.ToUpper() == "S" ? ScopeType.Meal.ToString() : ScopeType.Stay.ToString(),
            AgeFrom = condtos.D4desd,
            AgeTo = condtos.D4has,
            Amount = condtos.D4dtos,
            AmountType = Dtos.BookingCenter.Availability.TypeOfPayment.Percent.ToString(),
            PeriodPricingCode = condtos.PeriodPricingCode,
            Code = condtos.Code
        };
    }
}
