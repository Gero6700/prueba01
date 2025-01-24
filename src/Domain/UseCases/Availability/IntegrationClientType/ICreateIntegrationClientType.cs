namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
public interface ICreateIntegrationClientType {
    Task<HttpResponseMessage> Execute(Restagen restagen);
}
