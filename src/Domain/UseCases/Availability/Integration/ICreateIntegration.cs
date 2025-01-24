namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
public interface ICreateIntegration {
    Task<HttpResponseMessage> Execute(Usureg usureg);
}
