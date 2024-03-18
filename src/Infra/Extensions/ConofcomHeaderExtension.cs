namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions;
public static class ConofcomHeaderExtension{

    public static OfferAndSupplementGroup ToOfferAndSupplementGroup(this ConofcomHeader conofcomHeader) {
        return new OfferAndSupplementGroup {
            Code = conofcomHeader.Occin.ToString(),
            ApplyFrom = conofcomHeader.Ocfec1 == 0 ? DateTime.MinValue : DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec1),
            ApplyTo = conofcomHeader.Ocfec2 == 0 ? DateTime.MinValue : DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec2)
        };
    }
}
