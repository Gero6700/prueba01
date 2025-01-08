namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Inventory;
public interface IUpdateInventory {
    Task<HttpResponseMessage> Execute(Resplaht resplaht);
}
