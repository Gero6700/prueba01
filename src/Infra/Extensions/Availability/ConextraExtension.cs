
namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ConextraExtension {
    public static ExtraDto ToExtra(this Conextra conextra) {
        var extra = new ExtraDto {
            Code = conextra.Code,
            ApplyFrom = DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(conextra.C5fred),
            ApplyTo = DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(conextra.C5freh),
            CheckInFrom = DateTimeHelper.ConvertYYYYMMDDToDatetime(conextra.C5fec1),
            CheckInTo = DateTimeHelper.ConvertYYYYMMDDToDatetime(conextra.C5fec2),
            StayFrom = conextra.C5died,
            StayTo = conextra.C5dieh,
            Mandatory = conextra.C5Sele == "S" ? false : true,
            Quantity = conextra.C5unid,
            ByDay = conextra.C5inta,
            ApplyBy = conextra.C5foun == "D" ? ApplyStayPriceType.D : conextra.C5foun == "P" ? ApplyStayPriceType.P : conextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = conextra.C5prec,
            PriceApplication = conextra.C5form == "D" ? ApplyStayPriceType.D : conextra.C5form == "P" ? ApplyStayPriceType.P : conextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            DiscountApplicationType = conextra.C5apdt == "C" ? ExtrasDiscountApplicationType.Contract : 
                conextra.C5apdt == "S" ? ExtrasDiscountApplicationType.Offer : 
                conextra.C5apdt == "T" ? ExtrasDiscountApplicationType.All : ExtrasDiscountApplicationType.None, 
            TaxesIncluded = conextra.TaxesIncluded, 
            IsCommissionable = conextra.IsCommissionable, 
            OccupancyRateCode = conextra.C5cocu == 0 ? "" : conextra.C5cocu.ToString(),
            IntegrationContractCodes = conextra.OriginType == OriginType.Contract ? [conextra.OriginCode] : null,
            OfferSupplementCodes = conextra.OriginType == OriginType.Offer ? [conextra.OriginCode] : null,
            ExtraPaxes = [],
            RoomCodes= null,
            MealCodes = null
        };
        extra.AddAdultPaxes(conextra);
        extra.AddChildPaxes(conextra);
        extra.AddRooms(conextra);
        extra.AddRegimes(conextra);

        return extra;
    }

    private static void AddChildPaxes(this ExtraDto extra, Conextra conextra) {
        const decimal ageFrom = 2;
        const decimal ageTo = 14.99m;
        const PaxType type = PaxType.Child;
        const Dtos.BookingCenter.Availability.TypeOfPayment payment = Dtos.BookingCenter.Availability.TypeOfPayment.Percent;

        var paxes = new List<ExtraPaxDto>();
        if (conextra.C5dtn1 != 0) {
            paxes.Add(new ExtraPaxDto {
                PaxOrder = 1,
                PaxType = type,                
                AgeFrom = ageFrom,
                AgeTo = ageTo,
                Amount = conextra.C5dtn1,
                AmountType = payment
            });
        }
        if (conextra.C5dtn2 != 0) {
            paxes.Add(new ExtraPaxDto {
                PaxOrder = 2,
                PaxType = type,
                AgeFrom = ageFrom,
                AgeTo = ageTo,
                Amount = conextra.C5dtn2,
                AmountType = payment
            });
        }
        if (conextra.C5dtn3 != 0) {
            paxes.Add(new ExtraPaxDto {
                PaxOrder = 3,
                PaxType = type,
                AgeFrom = ageFrom,
                AgeTo = ageTo,
                Amount = conextra.C5dtn3,
                AmountType = payment
            });
        }
        if (conextra.C5dtn4 != 0) {
            paxes.Add(new ExtraPaxDto {
                PaxOrder = 4,
                PaxType = type,
                AgeFrom = ageFrom,
                AgeTo = ageTo,
                Amount = conextra.C5dtn4,
                AmountType = payment
            });
        }

        paxes.ForEach(pax => extra.ExtraPaxes.ToList().Add(pax));
    }

    private static void AddAdultPaxes(this ExtraDto extra, Conextra conextra) {
        const decimal ageFrom = 15;
        const decimal ageTo = 999;
        const PaxType type = PaxType.Adult;
        const TypeOfPayment payment = TypeOfPayment.Percent;

        var paxes = new List<ExtraPaxDto>();
        if (conextra.C5dta1 != 0) {
            paxes.Add(new ExtraPaxDto {
                PaxOrder = 1,
                PaxType = type,
                AgeFrom = ageFrom,
                AgeTo = ageTo,
                Amount = conextra.C5dta1,
                AmountType = payment
            });
        }
        if (conextra.C5dta2 != 0) {
            paxes.Add(new ExtraPaxDto {
                PaxOrder = 2,
                PaxType = type,
                AgeFrom = ageFrom,
                AgeTo = ageTo,
                Amount = conextra.C5dta2,
                AmountType = payment
            });
        }
        if (conextra.C5dta3 != 0) {
            paxes.Add(new ExtraPaxDto {
                PaxOrder = 3,
                PaxType = type,
                AgeFrom = ageFrom,
                AgeTo = ageTo,
                Amount = conextra.C5dta3,
                AmountType = payment
            });
        }
        if (conextra.C5dta4 != 0) {
            paxes.Add(new ExtraPaxDto {
                PaxOrder = 4,
                PaxType = type,
                AgeFrom = ageFrom,
                AgeTo = ageTo,
                Amount = conextra.C5dta4,
                AmountType = payment
            });
        }

        paxes.ForEach(pax => extra.ExtraPaxes.ToList().Add(pax));
    }

    private static void AddRooms(this ExtraDto extra, Conextra conextra) {
        var rooms = new List<string>();

        if (!string.IsNullOrEmpty(conextra.C5th01)) {
            rooms.Add(conextra.C5th01);
        }
        if (!string.IsNullOrEmpty(conextra.C5th02)) {
            rooms.Add(conextra.C5th02);
        }
        if (!string.IsNullOrEmpty(conextra.C5th03)) {
            rooms.Add(conextra.C5th03);
        }
        if (!string.IsNullOrEmpty(conextra.C5th04)) {
            rooms.Add(conextra.C5th04);
        }
        if (!string.IsNullOrEmpty(conextra.C5th05)) {
            rooms.Add(conextra.C5th05);
        }
        if (!string.IsNullOrEmpty(conextra.C5th06)) {
            rooms.Add(conextra.C5th06);
        }
        if (!string.IsNullOrEmpty(conextra.C5th07)) {
            rooms.Add(conextra.C5th07);
        }
        if (!string.IsNullOrEmpty(conextra.C5th08)) {
            rooms.Add(conextra.C5th08);
        }
        if (!string.IsNullOrEmpty(conextra.C5th09)) {
            rooms.Add(conextra.C5th09);
        }
        if (!string.IsNullOrEmpty(conextra.C5th10)) {
            rooms.Add(conextra.C5th10);
        }
        if (!string.IsNullOrEmpty(conextra.C5th11)) {
            rooms.Add(conextra.C5th11);
        }
        if (!string.IsNullOrEmpty(conextra.C5th12)) {
            rooms.Add(conextra.C5th12);
        }
        if (!string.IsNullOrEmpty(conextra.C5th13)) {
            rooms.Add(conextra.C5th13);
        }
        if (!string.IsNullOrEmpty(conextra.C5th14)) {
            rooms.Add(conextra.C5th14);
        }
        if (!string.IsNullOrEmpty(conextra.C5th15)) {
            rooms.Add(conextra.C5th15);
        }

        extra.RoomCodes = rooms.Count > 0 ? rooms : null;
    }

    private static void AddRegimes(this ExtraDto extra, Conextra conextra) {
        var regimes = new List<string>();

        if (!string.IsNullOrEmpty(conextra.C5reg1)) {
            regimes.Add(conextra.C5reg1);
        }
        if (!string.IsNullOrEmpty(conextra.C5reg2)) {
            regimes.Add(conextra.C5reg2);
        }
        if (!string.IsNullOrEmpty(conextra.C5reg3)) {
            regimes.Add(conextra.C5reg3);
        }
        if (!string.IsNullOrEmpty(conextra.C5reg4)) {
            regimes.Add(conextra.C5reg4);
        }
        if (!string.IsNullOrEmpty(conextra.C5reg5)) {
            regimes.Add(conextra.C5reg5);
        }

        extra.MealCodes = regimes.Count > 0 ? regimes : null;
    }
}

