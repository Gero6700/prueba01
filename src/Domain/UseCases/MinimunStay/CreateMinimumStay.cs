namespace Senator.As400.Cloud.Sync.Application.UseCases.MinimunStay;
public class CreateMinimumStay {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMinimumStay(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conestmi conestmi) {
        var minimumStay = conestmi.toMinimumStay();
        await availabilitySynchronizerApiClient.CreateMinimumStay(minimumStay);
    }
}
