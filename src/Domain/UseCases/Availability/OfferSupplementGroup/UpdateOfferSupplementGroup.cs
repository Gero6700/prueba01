namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
public class UpdateOfferSupplementGroup : IUpdateOfferSupplementGroup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOfferSupplementGroup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(ConofcomHeader conofcomHeader) {
        if (conofcomHeader.Ocfec1 != 0 && conofcomHeader.Ocfec2 != 0 && DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec2) < DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec1)) {
            throw new ArgumentException("Apply to date is less than apply from date");
        }

        var offerAndSupplementGroup = conofcomHeader.ToOfferAndSupplementGroup();

        return await availabilitySynchronizerApiClient.UpdateOfferSupplementGroup(offerAndSupplementGroup);
    }
}
