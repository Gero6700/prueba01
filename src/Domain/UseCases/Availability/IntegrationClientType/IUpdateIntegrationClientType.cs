namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
public interface IUpdateIntegrationClientType {
    Task<HttpResponseMessage> Execute(Restagen restagen);
}
