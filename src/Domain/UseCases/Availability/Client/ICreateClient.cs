namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
public interface ICreateClient {
    Task<HttpResponseMessage> Execute(Usureg usureg);
}
