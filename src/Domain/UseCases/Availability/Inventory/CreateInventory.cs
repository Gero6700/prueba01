namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Inventory;
public class CreateInventory : ICreateInventory {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateInventory(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Resplaht resplaht) {
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(resplaht.Ptfec) == DateTime.MinValue) {
            throw new ArgumentException("Invalid date");
        }
        if (!DateTime.TryParse(resplaht.Fechamodi, out _)) {
            throw new ArgumentException("Invalid last update date");
        }
        if (resplaht.Pthot == 0) {
            throw new ArgumentException("Incorrect hotel code");
        }
        if (string.IsNullOrWhiteSpace(resplaht.Pthab)) {
            throw new ArgumentException("Incorrect room code");
        }
        var inventory = resplaht.ToInventory();
        return await availabilitySynchronizerApiClient.CreateInventory(inventory);
    }
}

