namespace Senator.As400.Cloud.Sync.Infrastructure.Persistence.Repositories;
public class ServicioCategoriaRepository(IUnitOfWork unitOfWork)
    : Repository<ServicioCategoria>(unitOfWork), IServicioCategoriaRepository {
    public async Task<IEnumerable<ServicioCategoria>?> GetByNombresAsync(IEnumerable<string> nombres) {
        SetIdentityColumnTo<ServicioCategoria>();
        var getServicioCategoriaQuery = GetServicioCategoriaQuery();
        var getServicioCategoriaByNombresQueryTemplate = GetServicioCategoriaByNombresQueryTemplate(getServicioCategoriaQuery, nombres);
        var servicioCategorias = await Connection.QueryAsync<ServicioCategoria>(
            sql: getServicioCategoriaByNombresQueryTemplate.RawSql, 
            param: getServicioCategoriaByNombresQueryTemplate.Parameters, 
            transaction: Transaction);

        return !servicioCategorias.Any() ? null : servicioCategorias;
    }

    private string GetServicioCategoriaQuery() {
        return $@"
            SELECT 
                {GetTableColumnsOf<ServicioCategoria>("sc")}
            FROM
                {SqlQueryBuilder.GetTableName(typeof(ServicioCategoria))} sc
            /**where**/";
    }
    private void SetIdentityColumnTo<T>() {
        SqlQueryBuilder.SetIdentityColumnCustomMap(typeof(T));
    }

    private string GetTableColumnsOf<T>(string tableAlias) {
        return SqlQueryBuilder.GetTableColumnsWithAlias(typeof(T), tableAlias);
    }

    private static SqlBuilder.Template GetServicioCategoriaByNombresQueryTemplate(string query, IEnumerable<string> nombres) {
        var getServicioCategoriaByNombresQueryBuilder = new SqlBuilder();
        var template = getServicioCategoriaByNombresQueryBuilder.AddTemplate(query);
        foreach (var nombre in nombres) {
            if (string.IsNullOrEmpty(nombre)) {
                continue;
            }
            getServicioCategoriaByNombresQueryBuilder.Where($"es_nombre LIKE ('%{nombre}%')");
        }
        return template;
    }
}
