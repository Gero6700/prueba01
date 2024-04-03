using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Markup;
public class CreateMarkup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMarkup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Mkupcabe mkupcabe) {
        if (mkupcabe.Mkcbwd == DateTime.MinValue) {
            throw new ArgumentException("Booking window from is required");
        }
        if (mkupcabe.Mkcbwh == DateTime.MinValue) {
            throw new ArgumentException("Booking window to is required");
        }
        if (mkupcabe.Mkcfed == 0) {
            throw new ArgumentException("Stay date from is required");
        }
        if (mkupcabe.Mkcfeh == 0) {
            throw new ArgumentException("Stay date to is required");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(mkupcabe.Mkcfed) == DateTime.MinValue) {
            throw new ArgumentException("Stay date from is invalid");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(mkupcabe.Mkcfeh) == DateTime.MinValue) {
            throw new ArgumentException("Stay date to is invalid");
        }
        if (mkupcabe.Mkcbwh < mkupcabe.Mkcbwd) {
            throw new ArgumentException("Booking window to is less than boking window from");
        }
        if (mkupcabe.Mkcfeh < mkupcabe.Mkcfed) {
            throw new ArgumentException("Stay date to is less than stay date from");
        }
        if (mkupcabe.Mkccpor == 0) {
            throw new ArgumentException("Incorrect amount");
        }
        var markup = mkupcabe.ToMarkup();
        await availabilitySynchronizerApiClient.CreateMarkup(markup);
    }
}
