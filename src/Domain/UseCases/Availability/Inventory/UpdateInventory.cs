namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Inventory;

public class UpdateInventory :IUpdateInventory {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateInventory(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resplaht resplaht) {
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(resplaht.Ptfec) == DateTime.MinValue) {
            throw new ArgumentException("Invalid date");
        }
        if (resplaht.Pthot == 0) {
            throw new ArgumentException("Incorrect hotel code");
        }
        if (resplaht.Pthab == "") {
            throw new ArgumentException("Incorrect room code");
        }
        var inventory = resplaht.ToInventory();
        await availabilitySynchronizerApiClient.UpdateInventory(inventory);
    }
}
