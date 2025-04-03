namespace Senator.As400.Cloud.Sync.Infrastructure.Abstractions.Persistence;

public class UnitOfWork(IDbContext context) : IUnitOfWork {
    public UnitOfWorkState State { get; private set; } = UnitOfWorkState.Open;
    public IDbContext DbContext { get; } = context ?? throw new ArgumentNullException(nameof(context));
    private bool disposed;

    public void BeginTransaction() {
        DbContext.BeginTransaction();
    }

    public void Commit() {
        try {
            DbContext.Commit();
            State = UnitOfWorkState.Comitted;
        }
        catch {
            DbContext.Rollback();
            throw;
        }
    }

    public void Rollback() {
        DbContext.Rollback();
        State = UnitOfWorkState.RolledBack;
    }

    //public void Dispose() {
    //    Dispose(true);
    //    GC.SuppressFinalize(this);
    //}

    //protected virtual void Dispose(bool disposing) {
    //    if (disposed) return;
    //    if (disposing) {
    //        DbContext.Dispose();
    //    }
    //    disposed = true;
    //}
}