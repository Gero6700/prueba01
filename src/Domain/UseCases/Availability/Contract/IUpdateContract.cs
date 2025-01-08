namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Contract;
public interface IUpdateContract {
    Task<HttpResponseMessage> Execute(Concabec concabec);
}
