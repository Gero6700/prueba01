namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
public class CreateClientType : ICreateClientType {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateClientType(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Restagen restagen) {
        var clientType = restagen.ToClientType();
        return await availabilitySynchronizerApiClient.CreateClientType(clientType);
    }
}
