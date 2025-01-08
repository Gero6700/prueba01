namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;

public class DeleteClientType : IDeleteClientType {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteClientType(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Restagen restagen) {
        var clientType = restagen.ToClientType();
        return await availabilitySynchronizerApiClient.DeleteClientType(clientType.Code);
    }
}
