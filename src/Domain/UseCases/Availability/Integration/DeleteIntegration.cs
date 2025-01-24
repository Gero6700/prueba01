namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;

public class DeleteIntegration : IDeleteIntegration {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteIntegration(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Usureg usureg) {
        var client = usureg.ToClient();
        return await availabilitySynchronizerApiClient.DeleteIntegration(client.Code);
    }

}
