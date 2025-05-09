namespace Senator.As400.Cloud.Sync.Domain.Abstractions.Persistence;

public interface IDbContext : IDisposable {
    DbContextState State { get; }
    IDbConnection Connection { get; }
    IDbTransaction Transaction { get; }
    ISqlQueryBuilder SqlQueryBuilder { get; }

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