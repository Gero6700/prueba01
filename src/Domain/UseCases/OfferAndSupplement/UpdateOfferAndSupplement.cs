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
        if (DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid apply to date");
        }
        if (conofege.Offec > conofege.Offec2) {
            throw new ArgumentException("Apply to date is less than apply from date");
        }

        var offerAndSupplement = conofege.ToOfferAndSupplement();
        return availabilitySynchronizerApiClient.UpdateOfferAndSupplement(offerAndSupplement);
    }
}
