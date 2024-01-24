namespace Senator.As400.Cloud.Sync.Application.UseCases.Client;
public class UpdateClient {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateClient(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Usureg usureg) {
        var client = usureg.ToClient();
        await availabilitySynchronizerApiClient.UpdateClient(client);
    }
}

