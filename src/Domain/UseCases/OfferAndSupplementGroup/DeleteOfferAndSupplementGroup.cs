namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementGroup;
public class DeleteOfferAndSupplementGroup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteOfferAndSupplementGroup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(ConofcomHeader conofcomHeader) {
        var offerAndSupplementGroup = conofcomHeader.ToOfferAndSupplementGroup();
        await availabilitySynchronizerApiClient.DeleteOfferAndSupplementGroup(offerAndSupplementGroup.Code);
    }
}
