namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
public class CreateIntegrationClientType : ICreateIntegrationClientType {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateIntegrationClientType(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Restagen restagen) {
        var clientType = restagen.ToClientType();
        return await availabilitySynchronizerApiClient.CreateIntegrationClientType(clientType);
    }
}
