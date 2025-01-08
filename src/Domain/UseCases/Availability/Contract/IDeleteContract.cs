namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Contract;
public interface IDeleteContract {
    Task<HttpResponseMessage> Execute(string code);
}
