namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroupOfferAndSupplement;
public class DeleteOfferSupplementGroupRelation : IDeleteOfferSupplementGroupRelation {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteOfferSupplementGroupRelation(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(ConofcomLine conofcomLine) {
        if (conofcomLine.Occin == 0) {
            throw new ArgumentException("Group code is zero");
        }
        if (conofcomLine.Oocode == "") {
            throw new ArgumentException("Offer code is empty");
        }

        var offerAndSupplementGroupOfferAndSupplement = conofcomLine.ToOfferAndSupplementGroupOfferAndSupplement();
        return await availabilitySynchronizerApiClient.DeleteOfferSupplementGroupRelation(offerAndSupplementGroupOfferAndSupplement);
    }
}
