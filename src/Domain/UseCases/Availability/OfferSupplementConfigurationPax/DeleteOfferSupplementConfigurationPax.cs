namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;

public class DeleteOfferSupplementConfigurationPax : IDeleteOfferSupplementConfigurationPax {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteOfferSupplementConfigurationPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(string code) {
        if (code == "") {
            throw new ArgumentException("Code is required");
        }
        return await availabilitySynchronizerApiClient.DeleteOfferSupplementConfigurationPax(code);
    }
}
