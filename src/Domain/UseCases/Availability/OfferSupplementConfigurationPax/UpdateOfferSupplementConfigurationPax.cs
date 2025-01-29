namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;
public class UpdateOfferSupplementConfigurationPax : IUpdateOfferSupplementConfigurationPax {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOfferSupplementConfigurationPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Condtof condtof) {
        if (condtof.Code == "") {
            throw new ArgumentException("Code is required");
        }
        if (condtof.Codeof == "") {
            throw new ArgumentException("OfferAndSupplement code is required");
        }
        if (condtof.O4has < condtof.O4desd) {
            throw new ArgumentException("Age to is less than age from");
        }
        if (condtof.O4tipa == "") {
            throw new ArgumentException("Pax type is required");
        }
        if (condtof.O4tipa.Length < 6) {
            throw new ArgumentException("Pax type lenght is less than 6");
        }
        if (int.TryParse(condtof.O4tipa.Trim()[5..], out _) == false) {
            throw new ArgumentException("Pax order is not a number");
        }

        var offerAndSupplementConfigurationPax = condtof.ToOfferAndSupplementConfigurationPax();
        return await availabilitySynchronizerApiClient.UpdateOfferSupplementConfigurationPax(offerAndSupplementConfigurationPax);
    }
}
