namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Market;
public class DeleteMarket :IDeleteMarket {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteMarket(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Merca merca) {
        var market = merca.ToMarket();
        return await availabilitySynchronizerApiClient.DeleteMarket(market.Code);
    }

}
