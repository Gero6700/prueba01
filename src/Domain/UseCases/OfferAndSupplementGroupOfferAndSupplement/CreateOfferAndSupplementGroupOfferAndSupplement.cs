namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementGroupOfferAndSupplement;
public class CreateOfferAndSupplementGroupOfferAndSupplement {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateOfferAndSupplementGroupOfferAndSupplement(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(ConofcomLine conofcomLine) {
        if (conofcomLine.Occin == 0) {
            throw new ArgumentException("Group code is zero");
        }

        var offerAndSupplementGroupOfferAndSupplement = conofcomLine.ToOfferAndSupplementGroupOfferAndSupplement();
        await availabilitySynchronizerApiClient.CreateOfferAndSupplementGroupOfferAndSupplement(offerAndSupplementGroupOfferAndSupplement);
    }
}
