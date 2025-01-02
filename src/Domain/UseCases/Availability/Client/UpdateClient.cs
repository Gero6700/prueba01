namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
public class UpdateClient : IUpdateClient {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateClient(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Usureg usureg) {
        if (usureg.IdUsuario == 0) {
            throw new ArgumentException("Incorrect user code");
        }

        var client = usureg.ToClient();
        await availabilitySynchronizerApiClient.UpdateClient(client);
    }
}

