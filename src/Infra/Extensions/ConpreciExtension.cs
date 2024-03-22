namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ConpreciExtension {
    public static PeriodPricing ToPeriodPricing(this Conpreci conpreci) {
        return new PeriodPricing {
            ClosingSales = false,
            RateCode = conpreci.RateCode,
            PricingDate = DateTimeHelper.ConvertJulianDateToDateTime(conpreci.Cffec),
            StayPvp = conpreci.C4esta,
            StayPvpApplyMode = conpreci.C4form.ToUpper() == "P" ? ApplyStayPriceType.P : ApplyStayPriceType.P,
            RegimePvp = conpreci.C4serv,
            RegimePvpApplyMode = ApplyStayPriceType.P,
            OnRequest = false,
            Release = conpreci.Acrele,
            RoomCode = conpreci.C4thab,
            RegimeCode = conpreci.C4tser,
            ContractClientCode = conpreci.ContractClientCode,
        };
    }
}
