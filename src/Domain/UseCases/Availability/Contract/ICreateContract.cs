namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Contract;
public interface ICreateContract {
    Task<HttpResponseMessage> Execute(Concabec concabec);
}

