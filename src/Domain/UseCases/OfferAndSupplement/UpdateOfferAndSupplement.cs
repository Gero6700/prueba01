namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplement;
public class UpdateOfferAndSupplement {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOfferAndSupplement(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task Execute(Conofege conofege) {
        if (DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec) == DateTime.MinValue) {
            throw new ArgumentException("Invalid apply from date");
        }

        var offerAndSupplement = conofege.ToOfferAndSupplement();
        return availabilitySynchronizerApiClient.UpdateOfferAndSupplement(offerAndSupplement);
    }
}
