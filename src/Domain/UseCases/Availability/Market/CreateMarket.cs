namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Market;
public class CreateMarket :ICreateMarket {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMarket(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task<HttpResponseMessage> Execute(Merca merca) {
        if (merca.Cod == "") {
            throw new ArgumentException("Incorrect market code");
        }
        var market = merca.ToMarket();
        return availabilitySynchronizerApiClient.CreateMarket(market);
    }
}
