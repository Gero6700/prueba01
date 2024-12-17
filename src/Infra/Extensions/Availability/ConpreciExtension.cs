using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ConpreciExtension {
    public static PeriodPricing ToPeriodPricing(this Conpreci conpreci) {
        return new PeriodPricing {
            ClosingSales = conpreci.Rerele.ToUpper() == "CV" ? true : false,
            RateCode = conpreci.RateCode,
            PricingDate = DateTimeHelper.ConvertJulianDateToDateTime(conpreci.Cffec),
            StayPvp = conpreci.C4esta,
            StayPvpApplyMode = conpreci.C4form.ToUpper() == "P" ? ApplyStayPriceType.P : conpreci.C4form.ToUpper() == "D" ? ApplyStayPriceType.D : ApplyStayPriceType.P,
            RegimePvp = conpreci.C4serv,
            RegimePvpApplyMode = conpreci.C4fors.ToUpper() == "P" ? ApplyStayPriceType.P : conpreci.C4fors.ToUpper() == "D" ? ApplyStayPriceType.D : ApplyStayPriceType.P,
            OnRequest = conpreci.Rerele.ToUpper() == "OR" || conpreci.Tior.ToUpper() == "S" ? true : false,
            Release = conpreci.Acrele,
            RoomCode = conpreci.C4thab,
            RegimeCode = conpreci.C4tser,
            IntegrationContractId = conpreci.ContractClientCode,
        };
    }
}
