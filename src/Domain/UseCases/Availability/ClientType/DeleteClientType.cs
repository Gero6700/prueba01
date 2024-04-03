using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;

public class DeleteClientType {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteClientType(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task Execute(Restagen restagen) {
        var clientType = restagen.ToClientType();
        await availabilitySynchronizerApiClient.DeleteClientType(clientType.Code);
    }
}
