namespace Senator.As400.Cloud.Sync.Application.UseCases.Client;

public class DeleteClient {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteClient(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(long clientCode) {
        var cod = clientCode.ToString();
        await availabilitySynchronizerApiClient.DeleteClient(cod);
    }

}
