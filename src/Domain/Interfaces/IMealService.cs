namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IMealService {
    Task<Result<IEnumerable<Regimen>?>> GetAllAsync();
}
