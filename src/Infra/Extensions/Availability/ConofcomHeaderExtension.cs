
namespace Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;
public static class ConofcomHeaderExtension {

    public static OfferSupplementGroupDto ToOfferAndSupplementGroup(this ConofcomHeader conofcomHeader) {
        return new OfferSupplementGroupDto {
            Code = conofcomHeader.Occin.ToString(),
            ApplyFrom = DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(conofcomHeader.Ocfec1),
            ApplyTo = DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(conofcomHeader.Ocfec2),
            IntegrationContractCodes = conofcomHeader.ContractClientCode == "" ? [] : new List<string> { conofcomHeader.ContractClientCode }
        };
    }
}
