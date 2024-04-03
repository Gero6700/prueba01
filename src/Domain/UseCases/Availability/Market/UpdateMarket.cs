using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Market;

public class UpdateMarket {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateMarket(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Merca merca) {
        if (merca.Cod == "") {
            throw new ArgumentException("Incorrect market code");
        }
        var market = merca.ToMarket();
        await availabilitySynchronizerApiClient.UpdateMarket(market);
    }

}
