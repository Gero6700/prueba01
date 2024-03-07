namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplement;
public class CreateOfferAndSupplement {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateOfferAndSupplement(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conofege conofege) {
        var offerAndSupplement = conofege.ToOfferAndSupplement();

        await availabilitySynchronizerApiClient.CreateOfferAndSupplement(offerAndSupplement);
    }
}
