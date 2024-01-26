namespace Senator.As400.Cloud.Sync.Application.UseCases.Currency;
public class UpdateCurrency {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateCurrency(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Divisa divisa) {
        if (divisa.Dinom2.Length != 3 || !divisa.Dinom2.All(char.IsLetter)) {
            throw new ArgumentException("Invalid iso code");
        }

        var currency= divisa.ToCurrency();
        await availabilitySynchronizerApiClient.UpdateCurrency(currency);
        
    }
}
