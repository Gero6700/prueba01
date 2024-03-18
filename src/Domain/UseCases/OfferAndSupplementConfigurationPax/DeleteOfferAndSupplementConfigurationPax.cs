namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementConfigurationPax;

public class DeleteOfferAndSupplementConfigurationPax{
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteOfferAndSupplementConfigurationPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(string code) {
        if (code == "") {
            throw new ArgumentException("Code is required");
        }
        await availabilitySynchronizerApiClient.DeleteOfferAndSupplementConfigurationPax(code);
    }
}
