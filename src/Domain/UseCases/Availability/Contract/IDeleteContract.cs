namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Contract;
public interface IDeleteContract {
    Task Execute(string code);
}
