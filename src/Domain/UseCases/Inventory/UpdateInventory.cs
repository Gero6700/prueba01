namespace Senator.As400.Cloud.Sync.Application.UseCases.Inventory;

public class UpdateInventory{
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    
    public UpdateInventory(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resplaht resplaht) {
        if (DateTimeHelper.ConvertIntegerToDatetime(resplaht.Ptfec) == DateTime.MinValue) {
            throw new ArgumentException("Invalid date");
        }
        if (resplaht.Pthot == 0) {
            throw new ArgumentException("Incorrect hotel code");
        }
        if (resplaht.Pthab == "") {
            throw new ArgumentException("Incorrect room code");
        }
        var inventory= resplaht.ToInventory();
        await availabilitySynchronizerApiClient.UpdateInventory(inventory);
    }
}
