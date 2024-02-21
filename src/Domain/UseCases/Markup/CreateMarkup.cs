namespace Senator.As400.Cloud.Sync.Application.UseCases.Markup;
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
        if (DateTimeHelper.ConvertIntegerToDatetime(mkupcabe.Mkcfed) == DateTime.MinValue) {
            throw new ArgumentException("Stay date from is invalid");
        }
        if (DateTimeHelper.ConvertIntegerToDatetime(mkupcabe.Mkcfeh) == DateTime.MinValue) {
            throw new ArgumentException("Stay date to is invalid");
        }
        var markup = mkupcabe.ToMarkup();
        await availabilitySynchronizerApiClient.CreateMarkup(markup);
    }
}
