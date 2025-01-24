namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;

public class DeleteIntegrationClientType : IDeleteIntegrationClientType {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteIntegrationClientType(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Restagen restagen) {
        var clientType = restagen.ToClientType();
        return await availabilitySynchronizerApiClient.DeleteIntegrationClientType(clientType.Code);
    }
}
