namespace Senator.As400.Cloud.Sync.Application.UseCases.ClientType;
public class CreateClientType {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateClientType(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task Execute(Restagen restagen) {
        var clientType = restagen.ToClientType();
        await availabilitySynchronizerApiClient.CreateClientType(clientType);
    }
}
