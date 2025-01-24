namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
public interface IDeleteIntegrationClientType {
    Task<HttpResponseMessage> Execute(Restagen restagen);
}
