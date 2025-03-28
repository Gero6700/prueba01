namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Persistence;

public interface IUnitOfWork : IDisposable {
    UnitOfWorkState State { get; }
    IDbContext DbContext { get; }
    
    void BeginTransaction();
    void Commit();
    void Rollback();
}

public enum UnitOfWorkState {
    Open,
    Comitted,
    RolledBack
}