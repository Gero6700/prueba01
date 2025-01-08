namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Extra;
public interface ICreateExtra {
    Task<HttpResponseMessage> Execute(Conextra conextra);
}
