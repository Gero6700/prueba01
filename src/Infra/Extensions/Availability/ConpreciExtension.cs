namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ConpreciExtension {
    public static PeriodPricingDto ToPeriodPricing(this Conpreci conpreci) {
        return new PeriodPricingDto {
            Code = conpreci.Code,
            ClosingSales = conpreci.Rerele.ToUpper() == "CV" ? true : false,
            RateCode = conpreci.RateCode,
            PricingDate = DateTimeHelper.ConvertYYYYMMDDToDatetime(conpreci.Cffec),
            StayPvp = conpreci.C4esta,
            StayPvpApplyMode = conpreci.C4form.ToUpper() == "P" ? ApplyStayPriceType.P : conpreci.C4form.ToUpper() == "D" ? ApplyStayPriceType.D : ApplyStayPriceType.P,
            MealPvp = conpreci.C4serv,
            MealPvpApplyMode = conpreci.C4fors.ToUpper() == "P" ? ApplyStayPriceType.P : conpreci.C4fors.ToUpper() == "D" ? ApplyStayPriceType.D : ApplyStayPriceType.P,
            OnRequest = conpreci.Rerele.ToUpper() == "OR" || conpreci.Tior.ToUpper() == "S" ? true : false,
            Release = conpreci.Acrele,
            RoomCode = conpreci.C4thab,
            MealCode = conpreci.C4tser,
            IntegrationContractCode = conpreci.ContractClientCode,
        };
    }
}
