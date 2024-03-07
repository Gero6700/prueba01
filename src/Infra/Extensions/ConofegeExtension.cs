namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ConofegeExtension{
    public static OfferAndSupplement ToOfferAndSupplement(this Conofege conofege) {
        return new OfferAndSupplement {
            Code = conofege.Code,
            Type = conofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec),
            ApplyTo = DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec2),
            ApplyOrder = null,
            DepositAmount = conofege.Ofdpto,
            DepositType = conofege.Offode == "%" ? PaymentType.Percent : PaymentType.Fixed,
            DepositBeforeDate = conofege.Offtop == 0 ? null : DateTimeHelper.ConvertYYMMDDToDatetime(conofege.Offtop),
            ModificationCostsAmount = conofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = conofege.Ofopci.ToUpper() == "S",
                    StayType = conofege.Ofties.ToUpper() == "P" ? StayType.Period : conofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = conofege.Ofadni.ToUpper() == "A" ? PaxType.Adult :  conofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = conofege.Ofdiae,
                    MaxStayDays = conofege.Ofdieh,
                    MinReleaseDays = conofege.Offred,
                    MaxReleaseDays = conofege.Offres,
                    BookingWindowFrom = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbd),
                    BookingWindowTo = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbh),
                    OccupancyRateCod = conofege.Ofcocu.ToString(),
                    Rooms = conofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = conofege.GetRegimeCodes.Where(value => value != "").ToList(),
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = conofege.Ofdfac.Trim() == "" ? conofege.Ofdiae - conofege.Ofdiaf : conofege.Ofdiaf,
                    RoomTypeCodeToCalculatePrice = conofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = conofege.Oftsef,
                    ApplyStayPriceType = conofege.Offore.ToString() == "P" ? ApplyStayPriceType.P : conofege.Offore.ToString() == "X" ? ApplyStayPriceType.X : conofege.Offore.ToString() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = conofege.Ofpree,
                    ApplyRegimePriceType = conofege.Offors == "P" ? ApplyStayPriceType.P : ApplyStayPriceType.D,
                    ApplyRegimePrice = conofege.Ofpres,
                    DiscountAmount = conofege.Ofdtos,
                    DicountAmountType = PaymentType.Percent,
                    DiscountTarget = DiscountTargetType.Pvp,
                    DiscountScope = DiscountScopeType.All,
                    Paxes = []
                }    
            ]
        };
    }
}
