namespace Senator.As400.Cloud.Sync.Domain.Repositories;
public interface IServicioCategoriaRepository : IRepository<ServicioCategoria> {
    Task<IEnumerable<ServicioCategoria>?> GetByNombresAsync(IEnumerable<string> nombres);
}
