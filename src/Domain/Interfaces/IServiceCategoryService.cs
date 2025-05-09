namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IServiceCategoryService {
    Task<Result<IEnumerable<ServicioCategoria>?>> GetAllAsync();
    Task<Result<IEnumerable<ServicioCategoria>?>> GetByNombresAsync(IEnumerable<string> nombres);
}
