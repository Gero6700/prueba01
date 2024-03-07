using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

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
            Conditions = new List<OfferAndSupplementCondition> {
                new OfferAndSupplementCondition {
                    Optional = conofege.Ofopci.ToUpper() == "S",
                    StayType = conofege.Ofties.ToUpper() == "P" ? StayType.Period : StayType.CheckInDay,
                    ApplyToPax = PaxType.All,
                    MinStayDays = conofege.Ofdiae,
                    MaxStayDays = conofege.Ofdieh,
                    MinReleaseDays = conofege.Offred,
                    MaxReleaseDays = conofege.Offres,
                    BookingWindowFrom = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbd),
                    BookingWindowTo = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbh),
                    OccupancyRateCod = conofege.Ofcocu.ToString(),
                    Rooms = [],
                    Regimes = []
                }
            },
            Configurations = []
        };
    }
}
