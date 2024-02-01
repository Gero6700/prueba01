namespace Senator.As400.Cloud.Sync.Application.UseCases.Market;

public class UpdateMarket {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateMarket(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Merca merca) {
        var market = merca.ToMarket();
        await availabilitySynchronizerApiClient.UpdateMarket(market);
    }
    
}
