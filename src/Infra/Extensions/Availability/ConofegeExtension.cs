using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Availability;

namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

//TODO: Tener en cuenta los nullables
public static class ConofegeExtension {
    public static OfferAndSupplement ToOfferAndSupplement(this Conofege conofege) {
        return new OfferAndSupplement {
            Code = conofege.Code,
            ContractClients = conofege.ContractClientCode == "" ? [] : new List<string> { conofege.ContractClientCode },
            Type = conofege.Ofopci.ToUpper() == "S" ? OfferSupplementType.Offer : OfferSupplementType.Supplement,
            ApplyFrom = DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec),
            ApplyTo = DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec2),
            ApplyOrder = null,
            DepositAmount = conofege.Ofdpto,
            DepositType = conofege.Offode == "%" ? Dtos.BookingCenter.Availability.TypeOfPayment.Percent : Dtos.BookingCenter.Availability.TypeOfPayment.Fixed,
            DepositBeforeDate = conofege.Offtop == 0 ? null : DateTimeHelper.ConvertYYMMDDToDatetime(conofege.Offtop),
            ModificationCostsAmount = conofege.Gmimpo,
            Conditions = [
                new OfferAndSupplementCondition {
                    Optional = conofege.Ofopci.ToUpper() == "S",
                    StayType = conofege.Ofties.ToUpper() == "P" ? StayType.Period : conofege.Ofties.ToUpper() == "E" ? StayType.Stay : StayType.CheckInDay,
                    ApplyToPax = conofege.Ofadni.ToUpper() == "A" ? PaxType.Adult : conofege.Ofadni.ToUpper() == "N" ? PaxType.Child : PaxType.All,
                    MinStayDays = conofege.Ofdiae,
                    MaxStayDays = conofege.Ofdieh,
                    MinReleaseDays = conofege.Offred,
                    MaxReleaseDays = conofege.Offres,
                    BookingWindowFrom = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbd),
                    BookingWindowTo = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbh),
                    OccupancyRateCod = conofege.Ofcocu.ToString(), //TODO: Poner nulo cuando llegue cero
                    Rooms = conofege.GetRoomCodes.Where(value => value != "").ToList(),
                    Regimes = conofege.GetRegimeCodes.Where(value => value != "").ToList(),
                }
            ],
            Configurations = [
                new OfferAndSupplementConfiguration {
                    FreeDays = conofege.Ofdfac.Trim() == "" && conofege.Ofdiaf > 0 ? conofege.Ofdiae - conofege.Ofdiaf : conofege.Ofdiaf, //TODO: Sólo tendra valos si ofdiaf >0
                    RoomTypeCodeToCalculatePrice = conofege.Ofthaf,
                    RegimeTypeCodeToCalculatePrice = conofege.Oftsef,
                    ApplyStayPriceType = conofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : conofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : conofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = conofege.Ofpree,
                    ApplyRegimePriceType = conofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : conofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : conofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = conofege.Ofpres,
                    DiscountAmount = conofege.Ofdtos, //TODO:Transformar a positivo si es negativo
                    DicountAmountType = conofege.Oftidt.ToUpper() == "C" ? Dtos.BookingCenter.Availability.TypeOfPayment.Fixed : Dtos.BookingCenter.Availability.TypeOfPayment.Percent,
                    DiscountTarget = conofege.Ofsobr.ToUpper() == "B" ? DiscountTargetType.Net : conofege.Ofsobr.ToUpper() == "C" ? DiscountTargetType.Commission : DiscountTargetType.Pvp,
                    DiscountScope = conofege.Ofapli.ToUpper() == "E" ? DiscountScopeType.Stay : conofege.Ofapli.ToUpper() == "S" ? DiscountScopeType.Regime : DiscountScopeType.All
                }
            ]
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
