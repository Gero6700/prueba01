namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IServicioCategoriaService {
    Task<Result<IEnumerable<ServicioCategoria>?>> GetAllAsync();
    Task<Result<IEnumerable<ServicioCategoria>?>> GetByNombresAsync(IEnumerable<string> nombres);
}
