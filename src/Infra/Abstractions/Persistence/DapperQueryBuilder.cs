using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Core;
using Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Persistence;

namespace Senator.As400.Cloud.Sync.Infrastructure.Abstractions.Persistence;

public class DapperQueryBuilder : ISqlQueryBuilder {
    public void SetIdentityColumnCustomMap(Type type) {
        var identityColumnName = $"{type.Name}Id";
        var columnMaps = new Dictionary<string, string> {
            {identityColumnName, "Id"}
        };
        SetCustomMaps(type, columnMaps);
    }

    public string GetTableName(Type type) {
        var tableAttribute = type.GetCustomAttribute<TableAttribute>();
        return tableAttribute != null ? tableAttribute.Name.ToLower() : type.Name.ToLower();
    }

    public string? GetKeyColumnName(Type type) {
        var properties = type.GetProperties();

        foreach (var property in properties) {
            var keyAttributes = property.GetCustomAttributes(typeof(KeyAttribute), true);
            if (keyAttributes.Length <= 0) continue;
            var columnAttributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);
            if (columnAttributes.Length <= 0) return property.Name;
            var columnAttribute = (ColumnAttribute)columnAttributes[0];
            return columnAttribute.Name;
        }

        return null;
    }
    
    public string GetTableColumns(Type type, bool excludeKey = false) {
        return string.Join(", ", type.GetProperties()
            .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
            .Where(p => p.IsDefined(typeof(ColumnAttribute)))
            .Select(p => {
                var columnAttribute = p.GetCustomAttribute<ColumnAttribute>();
                return $"`{columnAttribute?.Name}`";
            }));
    }

    public string GetTableColumnsWithAlias(Type type, string tableAlias = "", bool excludeKey = false) {
        return string.Join(", ", type.GetProperties()
            .Where(p => !excludeKey || !p.IsDefined(typeof(KeyAttribute)))
            .Where(p => p.IsDefined(typeof(ColumnAttribute)))
            .Select(p => {
                var columnAttribute = p.GetCustomAttribute<ColumnAttribute>();
                return tableAlias == string.Empty
                    ? $"`{columnAttribute?.Name}` AS `{p.Name}`"
                    : $"{tableAlias}.`{columnAttribute?.Name}` AS `{p.Name}`";
            }));
    }

    public string GetPropertyNames(Type type, bool excludeKey = false) {
        var properties = type.GetProperties()
            .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null)
            .Where(p => p.GetCustomAttribute<ExcludeFromQueryAttribute>() == null);
        return string.Join(", ", properties.Select(p => $"@{p.Name}"));
    }

    public string? GetKeyPropertyName(Type type) {
        var properties = type.GetProperties()
            .Where(p => p.GetCustomAttribute<KeyAttribute>() != null).ToList();
        return properties.Count != 0 ? properties.FirstOrDefault()?.Name : null;
    }

    public IEnumerable<PropertyInfo> GetProperties(Type type, bool excludeKey = false) {
        return type.GetProperties()
            .Where(p => !excludeKey || p.GetCustomAttribute<KeyAttribute>() == null)
            .Where(p => p.GetCustomAttribute<ExcludeFromQueryAttribute>() == null);
    }
    
    public string GetCreateCommand(Type type) {
        var tableName = GetTableName(type);
        var tableColumns = GetTableColumns(type, excludeKey: true);
        var propertyNames = GetPropertyNames(type, excludeKey: true);
        return $"INSERT INTO {tableName} ({tableColumns}) VALUES ({propertyNames}); SELECT LAST_INSERT_ID();";
    }

    public string GetUpdateCommand(Type type) {
        var tableName = GetTableName(type);
        var keyColumn = GetKeyColumnName(type);
        var keyProperty = GetKeyPropertyName(type);
        var properties = GetProperties(type, true);
        var command = new StringBuilder();
        command.Append($"UPDATE {tableName} SET ");
        foreach (var property in properties) {
            var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
            var propertyName = property.Name;
            var columnName = columnAttribute!.Name;
            command.Append($" `{columnName}` = @{propertyName},");
        }
        command.Remove(command.Length - 1, 1);
        command.Append($" WHERE {keyColumn} = @{keyProperty}");
        return command.ToString();
    }

    private static void SetCustomMaps(Type type, Dictionary<string, string> columnMaps) {
        var mapper = new Func<Type, string, PropertyInfo>((t, columnName) =>
            columnMaps.TryGetValue(columnName, out var columnMap)
                ? t.GetProperty(columnMap)!
                : t.GetProperty(columnName)!);
        var customMap = new CustomPropertyTypeMap(type, (t, columnName) => mapper(t, columnName));
        SqlMapper.SetTypeMap(type, customMap);
    }
}