namespace Senator.As400.Cloud.Sync.Application.UseCases.Markup;

public class UpdateMarkup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateMarkup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
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
        var markup = mkupcabe.ToMarkup();  
        await availabilitySynchronizerApiClient.UpdateMarkup(markup);
    }
    
}
