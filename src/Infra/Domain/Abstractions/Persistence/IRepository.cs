namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Persistence;

public interface IRepository<TEntity> where TEntity : class {
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity?> GetByCodeAsync(string code);
    Task<int> CreateAsync(TEntity entity);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
}