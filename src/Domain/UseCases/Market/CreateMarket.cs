namespace Senator.As400.Cloud.Sync.Application.UseCases.Market;
public class CreateMarket {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMarket(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task Execute(Merca merca) {
        var market= merca.ToMarket();
        return availabilitySynchronizerApiClient.CreateMarket(market);
    }
}
