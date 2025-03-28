namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Persistence;

public interface IDbContext : IDisposable {
    IDbConnection Connection { get; }
    IDbTransaction Transaction { get; }
    ISqlQueryBuilder SqlQueryBuilder { get; }
    DbContextState State { get; }

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