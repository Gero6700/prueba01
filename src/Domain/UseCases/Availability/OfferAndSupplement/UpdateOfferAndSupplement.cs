namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplement;
public class UpdateOfferAndSupplement :IUpdateOfferAndSupplement {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOfferAndSupplement(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task<HttpResponseMessage> Execute(Conofege conofege) {
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Offec) == DateTime.MinValue) {
            throw new ArgumentException("Invalid apply from date");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Offec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid apply to date");
        }
        if (conofege.Offec > conofege.Offec2) {
            throw new ArgumentException("Apply to date is less than apply from date");
        }
        if (conofege.Offtop != 0 && DateTimeHelper.ConvertYYMMDDToDatetime(conofege.Offtop) == DateTime.MinValue) {
            throw new ArgumentException("Invalid deposit date");
        }
        if (conofege.Code == "") {
            throw new ArgumentException("Code is required");
        }
        if (conofege.Ofdieh < conofege.Ofdiae && conofege.Ofdieh > 0) {
            throw new ArgumentException("Max stay days is less than min stay days");
        }
        if (conofege.Offred > conofege.Offres && conofege.Offres > 0) {
            throw new ArgumentException("Max release days is less than min release days");
        }
        if (conofege.Ofgrbd > 0 && DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbd) == DateTime.MinValue) {
            throw new ArgumentException("Invalid booking window from date");
        }
        if (conofege.Ofgrbh > 0 && DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbh) == DateTime.MinValue) {
            throw new ArgumentException("Invalid booking window to date");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbd) > DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbh) && conofege.Ofgrbh > 0 && conofege.Ofgrbd > 0) {
            throw new ArgumentException("Booking window to date is less than booking window from date");
        }
        if (string.IsNullOrWhiteSpace(conofege.Ccode)) {
            throw new ArgumentException("Integration contract code is required");
        }

        var offerAndSupplement = conofege.ToOfferAndSupplement();
        return availabilitySynchronizerApiClient.UpdateOfferAndSupplement(offerAndSupplement);
    }
}
