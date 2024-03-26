using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class CondtosExtension {
    public static PeriodPricingPax ToPeriodPricingPax(this Condtos condtos) {
        return new PeriodPricingPax {
            PaxOrder = int.Parse(condtos.D4tipa.Trim()[5..]),
            PaxType = PaxType.Adult,
            Scope = ScopeType.Stay,
            AgeFrom = condtos.D4desd,
            AgeTo = condtos.D4has,
            Amount = condtos.D4dtos,
            AmountType = PaymentType.Percent,
            PeriodPricingCode = condtos.PeriodPricingCode,
            Code = condtos.Code
        };
    }
}
