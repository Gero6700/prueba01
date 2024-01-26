namespace Senator.As400.Cloud.Sync.Application.UseCases.Currency;
public class CreateCurrency {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateCurrency(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task Execute(Divisa divisa) {
        if (divisa.Dinom2 == "") {
            throw new ArgumentException("Incorrect currency code");
        }
        var currency = divisa.ToCurrency();
        await availabilitySynchronizerApiClient.CreateCurrency(currency);
    }
}
