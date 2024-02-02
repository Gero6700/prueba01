namespace Senator.As400.Cloud.Sync.Application.UseCases.Market;
public class DeleteMarket {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteMarket(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task Execute(Merca merca) {
        var market=merca.ToMarket();
        await availabilitySynchronizerApiClient.DeleteMarket(market);
    }
    
}
