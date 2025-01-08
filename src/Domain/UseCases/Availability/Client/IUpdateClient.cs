namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
public interface IUpdateClient {
    Task<HttpResponseMessage> Execute(Usureg client);
}
