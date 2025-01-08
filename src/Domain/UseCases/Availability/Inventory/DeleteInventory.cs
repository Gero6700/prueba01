namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Inventory;
public class DeleteInventory :IDeleteInventory {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteInventory(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Resplaht resplaht) {
        var inventory = resplaht.ToInventory();
        return await availabilitySynchronizerApiClient.DeleteInventory(inventory);
    }
}

