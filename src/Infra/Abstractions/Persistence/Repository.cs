namespace Senator.As400.Cloud.Sync.Infrastructure.Abstractions.Persistence;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {
    protected readonly IDbContext DbContext;
    protected readonly IDbConnection Connection;
    protected readonly IDbTransaction Transaction;
    protected readonly ISqlQueryBuilder SqlQueryBuilder;
    private readonly Type type = typeof(TEntity);

    public Repository(IUnitOfWork unitOfWork) {
        DbContext = unitOfWork.DbContext;
        Connection = DbContext.Connection;
        Transaction = DbContext.Transaction;
        SqlQueryBuilder = DbContext.SqlQueryBuilder;
    }

    //public Task<IEnumerable<TEntity>> GetAllAsync() {
    //    var tableName = SqlQueryBuilder.GetTableName(type);
    //    var query = $"SELECT * FROM {tableName}";
    //    return Connection.QueryAsync<TEntity>(query, Transaction);
    //}

    public Task<IEnumerable<TEntity>> GetAllAsync() {
        var tableName = SqlQueryBuilder.GetTableName(type);
        var query = $@"SELECT 
                {SqlQueryBuilder.GetTableColumnsWithAlias(type)}
            FROM {tableName}";
        return Connection.QueryAsync<TEntity>(query, Transaction);
    }
}