namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

public static class ConofegeExtension {
    public static OfferAndSupplement ToOfferAndSupplement(this Conofege conofege) {
        return new OfferAndSupplement {
            Code = conofege.Code,
            ContractClients = conofege.ContractClientCode == "" ? [] : [conofege.ContractClientCode],
            Type = conofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec),
            ApplyTo = DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec2),
            ApplyOrder = conofege.Ofpri == 0 ? null : conofege.Ofpri,
            DepositAmount = conofege.Ofdpto == 0 ? null : conofege.Ofdpto,
            DepositType = conofege.Ofdpto == 0 ? null : conofege.Offode == "%" ? TypeOfPayment.Percent : TypeOfPayment.Fixed,
            DepositBeforeDate = conofege.Offtop == 0 ? null : DateTimeHelper.ConvertYYMMDDToDatetime(conofege.Offtop),
            ModificationCostsAmount = conofege.Gmimpo == 0 ? null : conofege.Gmimpo,
            Condition = new OfferAndSupplementCondition {
                    StayType = conofege.Ofties.ToUpper() == "P" ? StayType.Period : conofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = conofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : conofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = conofege.Ofdiae == 0 ? null : conofege.Ofdiae,
                    MaxStayDays = conofege.Ofdieh == 0 ? null : conofege.Ofdieh,
                    MinReleaseDays = conofege.Offred == 0 ? null : conofege.Offred,
                    MaxReleaseDays = conofege.Offres == 0 ? null : conofege.Offres,
                    BookingWindowFrom = conofege.Ofgrbd == 0 ? null : DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbd),
                    BookingWindowTo = conofege.Ofgrbh == 0 ? null : DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbh),
                    OccupancyRateCod = conofege.Ofcocu == 0 ? null : conofege.Ofcocu.ToString(),
                    OnlyApplyIfRecordDatesOnWeekDays = "", //TODO: Pendiente de Jose
                    OnlyApplyIfStayDatesOnWeekDays = "", //TODO: Pendiente de Jose
                    WeekDaysApplicationMode = WeekDaysApplicationType.Always, //TODO: Pendiente de Jose
                    Rooms = conofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = conofege.GetRegimeCodes.Where(value => value != "").ToList(),
                },
            Configuration = new OfferAndSupplementConfiguration {
                    FreeDays = conofege.Ofdfac.Trim() == "" && conofege.Ofdiaf > 0 ? conofege.Ofdiae - conofege.Ofdiaf : conofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = conofege.Ofthaf.Trim() == "" ? null : conofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = conofege.Oftsef.Trim() == "" ? null : conofege.Oftsef,
                    ApplyStayPriceType = conofege.Ofpree == 0 ? null : conofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : conofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : conofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = conofege.Ofpree == 0 ? null : conofege.Ofpree,
                    ApplyRegimePriceType = conofege.Ofpres == 0 ? null : conofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : conofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : conofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = conofege.Ofpres == 0 ? null : conofege.Ofpres,
                    Amount = Math.Abs(conofege.Ofdtos), 
                    AmountType = conofege.Oftidt.ToUpper() == "C" ? TypeOfPayment.Fixed : TypeOfPayment.Percent,
                    Target = conofege.Ofsobr.ToUpper() == "B" ? DiscountTargetType.Net : conofege.Ofsobr.ToUpper() == "C" ? DiscountTargetType.Commission : DiscountTargetType.Pvp,
                    Scope = conofege.Ofapli.ToUpper() == "E" ? DiscountScopeType.Stay : conofege.Ofapli.ToUpper() == "S" ? DiscountScopeType.Regime : DiscountScopeType.All
                }
        };
    }

    private static IEnumerable<OfferAndSupplementConfigurationPax> CreatePaxConfigurations(List<decimal> discounts, PaxType paxType, ScopeType scopeType) {
        return discounts
            .Select((value, index) => new { Value = value, Index = index })
            .Where(item => item.Value > 0)
            .Select(item => new OfferAndSupplementConfigurationPax {
                PaxOrder = item.Index + 1,
                PaxType = paxType,
                Scope = scopeType,
                AgeFrom = 0,
                AgeTo = 0,
                Amount = item.Value,
                AmountType = Dtos.BookingCenter.Availability.TypeOfPayment.Percent
            });
    }
}
