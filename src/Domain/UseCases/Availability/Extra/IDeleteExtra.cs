namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Extra;
public interface IDeleteExtra {
    Task<HttpResponseMessage> Execute(Conextra conextra);
}
