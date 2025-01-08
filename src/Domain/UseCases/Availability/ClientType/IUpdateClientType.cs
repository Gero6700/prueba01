namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
public interface IUpdateClientType {
    Task<HttpResponseMessage> Execute(Restagen restagen);
}
