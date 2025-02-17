namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class ConofegeExtension {
    public static OfferSupplementDto ToOfferAndSupplement(this Conofege conofege) {
        return new OfferSupplementDto {
            Code = conofege.Code,
            IntegrationContractCodes = [conofege.Ccode],
            Name = conofege.OfDesc,
            Type = conofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer.ToString() : OfferSupplementType.Supplement.ToString(),
            ApplyFrom = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Offec),
            ApplyTo = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Offec2),
            ApplyOrder = conofege.Ofpri == 0 ? null : conofege.Ofpri,
            DepositAmount = conofege.Ofdpto == 0 ? null : conofege.Ofdpto,
            DepositType = conofege.Ofdpto == 0 ? null : conofege.Offode == "%" ? TypeOfPayment.Percent.ToString() : TypeOfPayment.Fixed.ToString(),
            DepositBeforeDate = conofege.Offtop == 0 ? null : DateTimeHelper.ConvertYYMMDDToDatetime(conofege.Offtop),
            ModificationCostsAmount = conofege.Gmimpo == 0 ? null : conofege.Gmimpo,
            OfferSupplementCondition = new OfferSupplementConditionDto {
                    StayType = conofege.Ofties.ToUpper() == "P" ? StayType.Period : conofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = conofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : conofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = conofege.Ofdiae == 0 ? null : conofege.Ofdiae,
                    MaxStayDays = conofege.Ofdieh == 0 ? null : conofege.Ofdieh,
                    MinReleaseDays = conofege.Offred == 0 ? null : conofege.Offred,
                    MaxReleaseDays = conofege.Offres == 0 ? null : conofege.Offres,
                    BookingWindowFrom = DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(conofege.Ofgrbd),
                    BookingWindowTo = DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(conofege.Ofgrbh),
                    //OccupancyRateCod = conofege.Ofcocu == 0 ? null : conofege.Ofcocu.ToString(),
                    OnlyApplyIfRecordDatesOnWeekDays = "", //TODO: Pendiente de Jose
                    OnlyApplyIfStayDatesOnWeekDays = "", //TODO: Pendiente de Jose
                    WeekDaysApplicationMode = WeekDaysApplicationType.Always.ToString(), //TODO: Pendiente de Jose
                    RoomCodes = conofege.GetRoomCodes.Where(value => value != "").ToList(),
                    MealCodes = conofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            OfferSupplementConfiguration = new OfferSupplementConfigurationDto {
                    FreeDays = conofege.Ofdfac.Trim() == "" && conofege.Ofdiaf > 0 ? conofege.Ofdiae - conofege.Ofdiaf : conofege.Ofdiaf,
                    RoomUsedToCalculatePrice = conofege.Ofthaf.Trim() == "" ? null : conofege.Ofthaf,
                    MealUsedToCalculatePrice = conofege.Oftsef.Trim() == "" ? null : conofege.Oftsef,
                    ApplyStayPriceType = conofege.Ofpree == 0 ? null : conofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P.ToString() : conofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X.ToString() : conofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U.ToString() : ApplyStayPriceType.D.ToString(),
                    ApplyStayPrice = conofege.Ofpree == 0 ? null : conofege.Ofpree,
                    ApplyMealPriceType = conofege.Ofpres == 0 ? null : conofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P.ToString() : conofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X.ToString() : conofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U.ToString() : ApplyStayPriceType.D.ToString(),
                    ApplyMealPrice = conofege.Ofpres == 0 ? null : conofege.Ofpres,
                    Amount = Math.Abs(conofege.Ofdtos), 
                    AmountType = conofege.Oftidt.ToUpper() == "C" ? TypeOfPayment.Fixed.ToString() : TypeOfPayment.Percent.ToString(),
                    Target = conofege.Ofsobr.ToUpper() == "B" ? DiscountTargetType.Net.ToString() : conofege.Ofsobr.ToUpper() == "C" ? DiscountTargetType.Commission.ToString() : DiscountTargetType.Pvp.ToString(),
                    Scope = conofege.Ofapli.ToUpper() == "E" ? DiscountScopeType.Stay.ToString() : conofege.Ofapli.ToUpper() == "S" ? DiscountScopeType.Regime.ToString().ToString() : DiscountScopeType.All.ToString()
                }
        };
    }

    //private static IEnumerable<OfferSupplementConfigurationPaxDto> CreatePaxConfigurations(List<decimal> discounts, PaxType paxType, ScopeType scopeType) {
    //    return discounts
    //        .Select((value, index) => new { Value = value, Index = index })
    //        .Where(item => item.Value > 0)
    //        .Select(item => new OfferSupplementConfigurationPaxDto {
    //            PaxOrder = item.Index + 1,
    //            PaxType = paxType,
    //            Scope = scopeType,
    //            AgeFrom = 0,
    //            AgeTo = 0,
    //            Amount = item.Value,
    //            AmountType = Dtos.BookingCenter.Availability.TypeOfPayment.Percent
    //        });
    //}
}
