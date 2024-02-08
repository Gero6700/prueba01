namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ConextraExtension {
    public static Extra ToExtra(this Conextra conextra) {
        return new Extra {
            Code = conextra.Code,
            ApplyFrom = DateTimeHelper.ConvertJulianDateToDateTime(conextra.C5fred),
            ApplyTo = DateTimeHelper.ConvertJulianDateToDateTime(conextra.C5freh),
            CheckInFrom = DateTimeHelper.ConvertJulianDateToDateTime(conextra.C5fec1),
            CheckInTo = DateTimeHelper.ConvertJulianDateToDateTime(conextra.C5fec2),
            StayFrom = conextra.C5died,
            StayTo = conextra.C5dieh,
            Mandatory = conextra.C5Sele=="S" ? false : true,
            Quantity = conextra.C5unid,
            ByDay = conextra.C5inta,
            ApplyBy = conextra.C5foun == "D" ? ApplyStayPriceType.D : conextra.C5foun == "P" ? ApplyStayPriceType.P : conextra.C5foun == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            Price = conextra.C5prec,
            PriceApplication = conextra.C5form == "D" ? ApplyStayPriceType.D : conextra.C5form == "P" ? ApplyStayPriceType.P : conextra.C5form == "X" ? ApplyStayPriceType.X : ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = conextra.C5apdt =="C" ? ApplyOtherSuplementsOrDiscounts.Contract : conextra.C5apdt == "S" ? ApplyOtherSuplementsOrDiscounts.Offer : ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = conextra.Cogc,
            OccupancyRateCod = conextra.C5cocu == 0 ? "" : conextra.C5cocu.ToString()
        };
    }
}

