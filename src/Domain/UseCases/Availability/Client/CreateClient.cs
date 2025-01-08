namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
public class CreateClient : ICreateClient {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateClient(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Usureg usureg) {
        if (usureg.IdUsuario == 0) {
            throw new ArgumentException("Incorrect user code");
        }

        var client = usureg.ToClient();
        return await availabilitySynchronizerApiClient.CreateClient(client);
    }
}

