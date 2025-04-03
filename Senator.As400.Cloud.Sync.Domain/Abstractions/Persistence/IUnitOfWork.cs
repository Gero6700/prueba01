namespace Senator.As400.Cloud.Sync.Domain.Abstractions.Persistence;

public interface IUnitOfWork {
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