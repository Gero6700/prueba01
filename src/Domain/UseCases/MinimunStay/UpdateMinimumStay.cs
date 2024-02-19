namespace Senator.As400.Cloud.Sync.Application.UseCases.MinimunStay;
public class UpdateMinimumStay {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateMinimumStay(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conestmi conestmi) {
        var minimumStay = conestmi.toMinimumStay();
        await availabilitySynchronizerApiClient.UpdateMinimumStay(minimumStay);
    }
}
