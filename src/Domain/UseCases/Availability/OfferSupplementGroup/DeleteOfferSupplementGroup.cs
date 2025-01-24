namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
public class DeleteOfferSupplementGroup :IDeleteOfferSupplementGroup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteOfferSupplementGroup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(ConofcomHeader conofcomHeader) {
        if (conofcomHeader.Occin == 0) {
            throw new ArgumentException("Group code is zero");
        }
        var offerAndSupplementGroup = conofcomHeader.ToOfferAndSupplementGroup();
        return await availabilitySynchronizerApiClient.DeleteOfferSupplementGroup(offerAndSupplementGroup.Code);
    }
}
