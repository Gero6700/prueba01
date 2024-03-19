namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementGroupOfferAndSupplement;
public class DeleteOfferAndSupplementGroupOfferAndSupplement {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteOfferAndSupplementGroupOfferAndSupplement(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(ConofcomLine conofcomLine) {
        var offerAndSupplementGroupOfferAndSupplement = conofcomLine.ToOfferAndSupplementGroupOfferAndSupplement();

        await availabilitySynchronizerApiClient.DeleteOfferAndSupplementGroupOfferAndSupplement(offerAndSupplementGroupOfferAndSupplement);
    }
}
