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
            ApplyBy = conextra.C5foun == "D" ? ApplyStayPriceType.D : ApplyStayPriceType.U,
            Price = conextra.C5prec,
            PriceApplication = ApplyStayPriceType.U,
            ApplyOtherSuplementsOrDiscounts = ApplyOtherSuplementsOrDiscounts.All,
            IsCancellationGuarantee = conextra.Cogc,
            OccupancyRateCod = conextra.C5cocu == 0 ? "" : conextra.C5cocu.ToString()
        };
    }
}

