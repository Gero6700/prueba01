namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementConfigurationPax;
public class UpdateOfferAndSupplementConfigurationPax {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOfferAndSupplementConfigurationPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
        
    public async Task Execute(Condtof condtof) {
        if (condtof.Code == "") {
            throw new ArgumentException("Code is required");
        }
        if (condtof.OfferAndSupplementCode == "") {
            throw new ArgumentException("OfferAndSupplement code is required");
        }

        var offerAndSupplementConfigurationPax = condtof.ToOfferAndSupplementConfigurationPax();
        await availabilitySynchronizerApiClient.UpdateOfferAndSupplementConfigurationPax(offerAndSupplementConfigurationPax);
    }
}
