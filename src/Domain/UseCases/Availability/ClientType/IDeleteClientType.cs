namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
public interface IDeleteClientType {
    Task<HttpResponseMessage> Execute(Restagen restagen);
}
