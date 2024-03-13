namespace Senator.As400.Cloud.Sync.Application.UseCases.OfferAndSupplement;
public class CreateOfferAndSupplement {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateOfferAndSupplement(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conofege conofege) {
        if (DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec) == DateTime.MinValue) {
            throw new ArgumentException("Invalid apply from date");
        }
        if (DateTimeHelper.ConvertJulianDateToDateTime(conofege.Offec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid apply to date");
        }
        if (conofege.Offec > conofege.Offec2) {
            throw new ArgumentException("Apply to date is less than apply from date");
        }
        if (conofege.Offtop != 0 && DateTimeHelper.ConvertYYMMDDToDatetime(conofege.Offtop) == DateTime.MinValue) {
            throw new ArgumentException("Invalid deposit date");
        }       

        var offerAndSupplement = conofege.ToOfferAndSupplement();
        await availabilitySynchronizerApiClient.CreateOfferAndSupplement(offerAndSupplement);
    }
}
