namespace Senator.As400.Cloud.Sync.Infrastructure.Abstractions.Persistence;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected readonly IDbContext DbContext;
    protected readonly IDbConnection Connection;
    protected readonly IDbTransaction Transaction;
    private readonly Type type = typeof(TEntity);

    public Repository(IUnitOfWork unitOfWork) {
        DbContext = unitOfWork.DbContext;
        Connection = DbContext.Connection;
        Transaction = DbContext.Transaction;
    }    
}