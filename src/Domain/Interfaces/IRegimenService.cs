namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IRegimenService {
    Task<Result<IEnumerable<Regimen>?>> GetAllAsync();
    Task<Result<IEnumerable<Regimen>?>> GetDistinctCodeAsync();
}
