namespace Senator.As400.Cloud.Sync.Application.UseCases.Client;

public class DeleteClient {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteClient(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Usureg usureg) {
        var client = usureg.ToClient();
        await availabilitySynchronizerApiClient.DeleteClient(client.Code);
    }

}
