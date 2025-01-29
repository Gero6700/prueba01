
namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ConofcomHeaderExtension {

    public static OfferSupplementGroupDto ToOfferAndSupplementGroup(this ConofcomHeader conofcomHeader) {
        return new OfferSupplementGroupDto {
            Code = conofcomHeader.Occin.ToString(),
            ApplyFrom = conofcomHeader.Ocfec1 == 0 ? DateTime.MinValue : DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec1),
            ApplyTo = conofcomHeader.Ocfec2 == 0 ? DateTime.MinValue : DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec2),
            IntegrationContractCodes = conofcomHeader.Occode == "" ? [] : new List<string> { conofcomHeader.Occode }
        };
    }
}
