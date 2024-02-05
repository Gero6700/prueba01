namespace Senator.As400.Cloud.Sync.Application.UseCases.Inventory;
public class CreateInventory {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateInventory(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resplaht resplaht) {
        var inventory= resplaht.ToInventory();
        await availabilitySynchronizerApiClient.CreateInventory(inventory);
    }
}

