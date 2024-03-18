namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementGroup;
public class CreateOfferAndSupplementGroup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateOfferAndSupplementGroup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(ConofcomHeader conofcomHeader) {
        if (conofcomHeader.Ocfec2 < conofcomHeader.Ocfec1) {
            throw new ArgumentException("Apply to date is less than apply from date");
        }

        var offerAndSupplementGroup = conofcomHeader.ToOfferAndSupplementGroup();
        await availabilitySynchronizerApiClient.CreateOfferAndSupplementGroup(offerAndSupplementGroup);
    }
}
