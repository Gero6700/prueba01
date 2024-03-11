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
                    ApplyStayPriceType = conofege.Offore.ToUpper() == "P" ? ApplyStayPriceType.P : conofege.Offore.ToUpper() == "X" ? ApplyStayPriceType.X : conofege.Offore.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyStayPrice = conofege.Ofpree,
                    ApplyRegimePriceType = conofege.Offors.ToUpper() == "P" ? ApplyStayPriceType.P : conofege.Offors.ToUpper() == "X" ? ApplyStayPriceType.X : conofege.Offors.ToUpper() == "U" ? ApplyStayPriceType.U : ApplyStayPriceType.D,
                    ApplyRegimePrice = conofege.Ofpres,
                    DiscountAmount = conofege.Ofdtos,
                    DicountAmountType = conofege.Oftidt.ToUpper() == "C" ? PaymentType.Fixed : PaymentType.Percent,
                    DiscountTarget = conofege.Ofsobr.ToUpper() == "B" ? DiscountTargetType.Net : conofege.Ofsobr.ToUpper() == "C" ? DiscountTargetType.Commission : DiscountTargetType.Pvp,
                    DiscountScope = conofege.Ofapli.ToUpper() == "E" ? DiscountScopeType.Stay : conofege.Ofapli.ToUpper() == "S" ? DiscountScopeType.Regime : DiscountScopeType.All,
                    Paxes = conofege.GetAdultStayDiscounts
                        .Select((value, index) => new { Value = value, Index = index })
                        .Where(item => item.Value > 0)
                        .Select(item => new OfferAndSupplementConfigurationPax {
                            PaxOrder = item.Index + 1,
                            PaxType = PaxType.Adult,
                            Scope = ScopeType.Stay,
                            AgeFrom = 0,
                            AgeTo = 0,
                            Amount = item.Value,
                            AmountType = PaymentType.Percent
                        })
                        .Union(conofege.GetAdultRegimeDiscounts
                        .Select((value, index) => new { Value = value, Index = index })
                        .Where(item => item.Value > 0)
                        .Select(item => new OfferAndSupplementConfigurationPax {
                                PaxOrder = item.Index + 1,
                                PaxType = PaxType.Adult,
                                Scope = ScopeType.Regime,
                                AgeFrom = 0,
                                AgeTo = 0,
                                Amount = item.Value,
                                AmountType = PaymentType.Percent
                        })).ToList()
                }    
            ]
        };
    }
}
