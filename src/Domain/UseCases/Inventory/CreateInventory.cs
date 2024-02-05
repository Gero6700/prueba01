namespace Senator.As400.Cloud.Sync.Application.UseCases.Inventory;
public class CreateInventory {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateInventory(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resplaht resplaht) {
        if (DateTimeHelper.ConvertIntegerToDatetime(resplaht.Ptfec) == DateTime.MinValue) {
            throw new ArgumentException("Invalid date");
        }
        var inventory= resplaht.ToInventory();
        await availabilitySynchronizerApiClient.CreateInventory(inventory);
    }
}

