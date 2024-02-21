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
        var markup = mkupcabe.ToMarkup();
        await availabilitySynchronizerApiClient.CreateMarkup(markup);
    }
}
