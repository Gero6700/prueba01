namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplementConfigurationPax;
public class CreateOfferAndSupplementConfigurationPax {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateOfferAndSupplementConfigurationPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Condtof condtof) {
        if (condtof.Code == "") {
            throw new ArgumentException("Code is required");
        }
        if (condtof.OfferAndSupplementCode == "") {
            throw new ArgumentException("OfferAndSupplement Code is required");
        }
        var offerAndSupplementConfigurationPax = condtof.ToOfferAndSupplementConfigurationPax();
        await availabilitySynchronizerApiClient.CreateOfferAndSupplementConfigurationPax(offerAndSupplementConfigurationPax);
    }    
}
