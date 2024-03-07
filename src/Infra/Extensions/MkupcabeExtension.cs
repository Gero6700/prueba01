namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class MkupcabeExtension {
    public static Markup ToMarkup(this Mkupcabe mkupcabe) {
        return new Markup {
            Code = mkupcabe.Mkcid.ToString(),
            CreationDate = mkupcabe.Mkcgrb,
            BookingWindowFrom = mkupcabe.Mkcbwd,
            BookingWindowTo = mkupcabe.Mkcbwh,
            StayFrom = DateTimeHelper.ConvertYYYYMMDDToDatetime(mkupcabe.Mkcfed),
            StayTo = DateTimeHelper.ConvertYYYYMMDDToDatetime(mkupcabe.Mkcfeh),
            Amount = mkupcabe.Mkccpor
        };
    }
}
