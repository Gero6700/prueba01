namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroupOfferAndSupplement;
public class CreateOfferAndSupplementGroupOfferAndSupplement :ICreateOfferAndSupplementGroupOfferAndSupplement {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateOfferAndSupplementGroupOfferAndSupplement(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(ConofcomLine conofcomLine) {
        if (conofcomLine.Occin == 0) {
            throw new ArgumentException("Group code is zero");
        }
        if (conofcomLine.OfferSupCode == "") {
            throw new ArgumentException("Offer code is empty");
        }

        var offerAndSupplementGroupOfferAndSupplement = conofcomLine.ToOfferAndSupplementGroupOfferAndSupplement();
        return await availabilitySynchronizerApiClient.CreateOfferAndSupplementGroupOfferAndSupplement(offerAndSupplementGroupOfferAndSupplement);
    }
}
