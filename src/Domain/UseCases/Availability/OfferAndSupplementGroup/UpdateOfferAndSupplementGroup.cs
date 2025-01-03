namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
public class UpdateOfferAndSupplementGroup : IUpdateOfferAndSupplementGroup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOfferAndSupplementGroup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(ConofcomHeader conofcomHeader) {
        if (conofcomHeader.Ocfec1 != 0 && conofcomHeader.Ocfec2 != 0 && DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec2) < DateTimeHelper.ConvertYYYYMMDDToDatetime(conofcomHeader.Ocfec1)) {
            throw new ArgumentException("Apply to date is less than apply from date");
        }

        var offerAndSupplementGroup = conofcomHeader.ToOfferAndSupplementGroup();

        await availabilitySynchronizerApiClient.UpdateOfferAndSupplementGroup(offerAndSupplementGroup);
    }
}
