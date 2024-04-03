using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;
using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
public class CreateClient {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateClient(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Usureg usureg) {
        if (usureg.IdUsuario == 0) {
            throw new ArgumentException("Incorrect user code");
        }

        var client = usureg.ToClient();
        await availabilitySynchronizerApiClient.CreateClient(client);
    }
}

