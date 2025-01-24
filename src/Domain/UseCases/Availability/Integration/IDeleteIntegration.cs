namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
public interface IDeleteIntegration {
    Task<HttpResponseMessage> Execute(Usureg usureg);
}
