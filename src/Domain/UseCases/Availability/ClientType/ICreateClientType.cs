namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
public interface ICreateClientType {
    Task<HttpResponseMessage> Execute(Restagen restagen);
}
