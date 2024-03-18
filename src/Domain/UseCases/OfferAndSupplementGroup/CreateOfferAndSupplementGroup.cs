namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementGroup;
public class CreateOfferAndSupplementGroup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateOfferAndSupplementGroup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(ConofcomHeader conofcomHeader) {
        var offerAndSupplementGroup = conofcomHeader.ToOfferAndSupplementGroup();

        await availabilitySynchronizerApiClient.CreateOfferAndSupplementGroup(offerAndSupplementGroup);
    }
}
