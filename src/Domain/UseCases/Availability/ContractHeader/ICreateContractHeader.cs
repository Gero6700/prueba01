namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Contract;
public interface ICreateContractHeader {
    Task<HttpResponseMessage> Execute(Concabec concabec);
}

