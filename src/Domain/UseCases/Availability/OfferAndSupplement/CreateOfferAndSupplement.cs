using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplement;
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
        if (conofege.Code == "") {
            throw new ArgumentException("Code is required");
        }
        if (conofege.Ofdieh < conofege.Ofdiae && conofege.Ofdieh > 0) {
            throw new ArgumentException("Max stay days is less than min stay days");
        }
        if (conofege.Offred > conofege.Offres && conofege.Offres > 0) {
            throw new ArgumentException("Max release days is less than min release days");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbd) > DateTimeHelper.ConvertYYYYMMDDToDatetime(conofege.Ofgrbh) && conofege.Ofgrbh > 0 && conofege.Ofgrbd > 0) {
            throw new ArgumentException("Booking window to date is less than booking window from date");
        }

        var offerAndSupplement = conofege.ToOfferAndSupplement();
        await availabilitySynchronizerApiClient.CreateOfferAndSupplement(offerAndSupplement);
    }
}
