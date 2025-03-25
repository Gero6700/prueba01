namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroupOfferAndSupplement;
public class CreateOfferSupplementGroupRelation :ICreateOfferSupplementGroupRelation {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateOfferSupplementGroupRelation(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(ConofcomLine conofcomLine) {
        if (string.IsNullOrEmpty(conofcomLine.Occin)) {
            throw new ArgumentException("Group code is empty");
        }
        if (conofcomLine.Oocode == "") {
            throw new ArgumentException("Offer code is empty");
        }

        var offerAndSupplementGroupOfferAndSupplement = conofcomLine.ToOfferAndSupplementGroupOfferAndSupplement();
        return await availabilitySynchronizerApiClient.CreateOfferSupplementGroupRelation(offerAndSupplementGroupOfferAndSupplement);
    }
}
