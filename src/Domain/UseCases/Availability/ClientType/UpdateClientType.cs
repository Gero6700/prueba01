namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;

public class UpdateClientType : IUpdateClientType {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateClientType(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Restagen restagen) {
        var clientType = restagen.ToClientType();
        await availabilitySynchronizerApiClient.UpdateClientType(clientType);
    }
}
