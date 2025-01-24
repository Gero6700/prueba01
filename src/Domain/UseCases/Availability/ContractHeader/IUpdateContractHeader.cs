namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Contract;
public interface IUpdateContractHeader {
    Task<HttpResponseMessage> Execute(Concabec concabec);
}
