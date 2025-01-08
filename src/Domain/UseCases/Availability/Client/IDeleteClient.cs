namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
public interface IDeleteClient {
    Task<HttpResponseMessage> Execute(Usureg usureg);
}
