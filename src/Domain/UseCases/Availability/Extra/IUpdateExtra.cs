namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Extra;
public interface IUpdateExtra {
    Task<HttpResponseMessage> Execute(Conextra conextra);
}
