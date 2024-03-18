namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ConofcomHeaderExtension{

    public static OfferAndSupplementGroup ToOfferAndSupplementGroup(this ConofcomHeader conofcomHeader) {
        return new OfferAndSupplementGroup {
            Code = conofcomHeader.Occin.ToString(),
            ApplyFrom = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec1),
            ApplyTo = DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec2)
        };
    }
}
