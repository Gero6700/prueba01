namespace Senator.As400.Cloud.Sync.Application.UseCases.Currency;
public class UpdateCurrency {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateCurrency(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Divisa divisa) {
        var currency= divisa.ToCurrency();
        await availabilitySynchronizerApiClient.UpdateCurrency(currency);
        
    }
}
