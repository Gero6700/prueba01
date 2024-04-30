using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class CondtosExtension {
    public static PeriodPricingPax ToPeriodPricingPax(this Condtos condtos) {
        var paxTypeString = condtos.D4tipa[..5].ToUpper();
        return new PeriodPricingPax {
            PaxOrder = int.Parse(condtos.D4tipa.Trim()[5..]),
            PaxType = paxTypeString == "NIÑOS" ? PaxType.Child : paxTypeString == "ADULT" && condtos.D4has < 18 ? PaxType.Teenager : PaxType.Adult,
            Scope = condtos.D4tdto.ToUpper() == "E" ? ScopeType.Stay : condtos.D4tdto.ToUpper() == "S" ? ScopeType.Regime : ScopeType.Stay,
            AgeFrom = condtos.D4desd,
            AgeTo = condtos.D4has,
            Amount = condtos.D4dtos,
            AmountType = Dtos.BookingCenter.Availability.TypeOfPayment.Percent,
            PeriodPricingCode = condtos.PeriodPricingCode,
            Code = condtos.Code
        };
    }
}
