namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Persistence;

public interface ISqlQueryBuilder {
    void SetIdentityColumnCustomMap(Type type);
    string GetTableName(Type type);
    string? GetKeyColumnName(Type type);
    string GetTableColumns(Type type, bool excludeKey = false);
    string GetTableColumnsWithAlias(Type type, string tableAlias = "", bool excludeKey = false);
    string GetPropertyNames(Type type, bool excludeKey = false);
    string? GetKeyPropertyName(Type type);
    IEnumerable<PropertyInfo> GetProperties(Type type, bool excludeKey = false);
    string GetCreateCommand(Type type);
    string GetUpdateCommand(Type type);
}