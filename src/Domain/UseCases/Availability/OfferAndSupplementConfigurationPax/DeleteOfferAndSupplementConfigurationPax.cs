namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;

public class DeleteOfferAndSupplementConfigurationPax : IDeleteOfferAndSupplementConfigurationPax {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteOfferAndSupplementConfigurationPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(string code) {
        if (code == "") {
            throw new ArgumentException("Code is required");
        }
        return await availabilitySynchronizerApiClient.DeleteOfferAndSupplementConfigurationPax(code);
    }
}
