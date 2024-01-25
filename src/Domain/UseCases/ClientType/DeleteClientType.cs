namespace Senator.As400.Cloud.Sync.Application.UseCases.ClientType;

public class DeleteClientType{
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteClientType(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task Execute(Restagen restagen) {
        var clientType = restagen.ToClientType();
        await availabilitySynchronizerApiClient.DeleteClientType(clientType.Code);
    }
}
