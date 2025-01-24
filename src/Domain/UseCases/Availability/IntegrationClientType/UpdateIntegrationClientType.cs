namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;

public class UpdateIntegrationClientType : IUpdateIntegrationClientType {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateIntegrationClientType(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Restagen restagen) {
        var clientType = restagen.ToClientType();
        return await availabilitySynchronizerApiClient.UpdateIntegrationClientType(clientType);
    }
}
