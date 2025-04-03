using System.Data;

namespace Senator.As400.Cloud.Sync.Domain.Abstractions.Persistence;

public interface IDbContext {
    DbContextState State { get; }
    IDbConnection Connection { get; }
    IDbTransaction Transaction { get; }

    void BeginTransaction();
    void Commit();
    void Rollback();
}

public enum DbContextState {
    Closed,
    Open,
    Comitted,
    RolledBack
}