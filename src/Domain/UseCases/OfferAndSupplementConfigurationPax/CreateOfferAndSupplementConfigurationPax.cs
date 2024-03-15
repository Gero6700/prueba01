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
        if (condtof.O4desd == 0) {
            throw new ArgumentException("Age from is required");
        }   
        if (condtof.O4has < condtof.O4desd) {
            throw new ArgumentException("Age to is less than age from");
        }
        
        var offerAndSupplementConfigurationPax = condtof.ToOfferAndSupplementConfigurationPax();
        await availabilitySynchronizerApiClient.CreateOfferAndSupplementConfigurationPax(offerAndSupplementConfigurationPax);
    }    
}
