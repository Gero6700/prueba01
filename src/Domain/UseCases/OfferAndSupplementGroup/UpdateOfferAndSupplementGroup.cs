namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementGroup;
public class UpdateOfferAndSupplementGroup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOfferAndSupplementGroup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(ConofcomHeader conofcomHeader) {
        var offerAndSupplementGroup = conofcomHeader.ToOfferAndSupplementGroup();

        await availabilitySynchronizerApiClient.UpdateOfferAndSupplementGroup(offerAndSupplementGroup);
    }
}
