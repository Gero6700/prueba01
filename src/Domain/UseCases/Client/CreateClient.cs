namespace Senator.As400.Cloud.Sync.Application.UseCases.Client;
public class CreateClient {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateClient(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Usureg usureg) {
        var client = usureg.ToClient();
        await availabilitySynchronizerApiClient.CreateClient(client);
    }
}

