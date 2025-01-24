namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
public interface IUpdateIntegration {
    Task<HttpResponseMessage> Execute(Usureg client);
}
