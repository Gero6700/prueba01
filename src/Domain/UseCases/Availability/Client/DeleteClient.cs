namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;

public class DeleteClient : IDeleteClient {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteClient(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Usureg usureg) {
        var client = usureg.ToClient();
        return await availabilitySynchronizerApiClient.DeleteClient(client.Code);
    }

}
