namespace Senator.As400.Cloud.Sync.Application.UseCases.Inventory;

public class UpdateInventory{
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    
    public UpdateInventory(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resplaht resplaht) {
        var inventory= resplaht.ToInventory();
        await availabilitySynchronizerApiClient.UpdateInventory(inventory);
    }
}
