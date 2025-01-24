namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Contract;
public interface IDeleteContractHeader {
    Task<HttpResponseMessage> Execute(string code);
}
