using Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Persistence;

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

    public async Task<TEntity?> GetByIdAsync(int id) {
        var tableName = SqlQueryBuilder.GetTableName(type);
        var keyColumn = SqlQueryBuilder.GetKeyColumnName(type);
        var query = $"SELECT * FROM {tableName} WHERE {keyColumn} = {id}";
        return await Connection.QuerySingleOrDefaultAsync<TEntity>(query, Transaction);
    }

    public async Task<TEntity?> GetByCodeAsync(string code) {
        var tableName = SqlQueryBuilder.GetTableName(type);
        var query = $"SELECT * FROM {tableName} WHERE code = '{code}'";
        return await Connection.QuerySingleOrDefaultAsync<TEntity>(query, Transaction);
    }

    public Task<IEnumerable<TEntity>> GetAllAsync() {
        var tableName = SqlQueryBuilder.GetTableName(type);
        var query = $"SELECT * FROM {tableName}";
        return Connection.QueryAsync<TEntity>(query, Transaction);
    }

    public async Task<int> CreateAsync(TEntity entity) {
        var tableName = SqlQueryBuilder.GetTableName(type);
        var tableColumns = SqlQueryBuilder.GetTableColumns(type, excludeKey: true);
        var propertyNames = SqlQueryBuilder.GetPropertyNames(type, excludeKey: true);
        var command = $"INSERT INTO {tableName} ({tableColumns}) VALUES ({propertyNames}); SELECT LAST_INSERT_ID();";
        var parameters = GenerateDynamicParameters(entity);
        return await Connection.ExecuteScalarAsync<int>(command, parameters, Transaction);
    }

    public async Task<bool> UpdateAsync(TEntity entity) {
        var tableName = SqlQueryBuilder.GetTableName(type);
        var keyColumn = SqlQueryBuilder.GetKeyColumnName(type);
        var keyProperty = SqlQueryBuilder.GetKeyPropertyName(type);

        var command = new StringBuilder();
        command.Append($"UPDATE {tableName} SET ");

        foreach (var property in SqlQueryBuilder.GetProperties(type, true)) {
            var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
            var propertyName = property.Name;
            var columnName = columnAttribute!.Name;
            command.Append($" `{columnName}` = @{propertyName},");
        }

        command.Remove(command.Length - 1, 1);
        command.Append($" WHERE {keyColumn} = @{keyProperty}");

        var parameters = GenerateDynamicParameters(entity);
        var rowsAffected = await Connection.ExecuteAsync(command.ToString(), parameters, Transaction);
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteAsync(TEntity entity) {
        var tableName = SqlQueryBuilder.GetTableName(type);
        var keyColumn = SqlQueryBuilder.GetKeyColumnName(type);
        var keyProperty = SqlQueryBuilder.GetKeyPropertyName(type);
        var command = $"DELETE FROM {tableName} WHERE {keyColumn} = @{keyProperty}";
        var rowsAffected = await Connection.ExecuteAsync(command, entity, Transaction);
        return rowsAffected > 0;
    }

    private DynamicParameters GenerateDynamicParameters(TEntity entity) {
        var parameters = new DynamicParameters();
        
        foreach (var prop in SqlQueryBuilder.GetProperties(typeof(TEntity))) {
            var value = prop.GetValue(entity);
            var isEnum = prop.PropertyType.IsEnum ||
                         (Nullable.GetUnderlyingType(prop.PropertyType)?.IsEnum ?? false);

            parameters.Add(prop.Name, isEnum ? value?.ToString() : value);
        }

        return parameters;
    }
}