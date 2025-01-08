namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Inventory;
public interface IDeleteInventory {
    Task<HttpResponseMessage> Execute(Resplaht resplaht);
}
