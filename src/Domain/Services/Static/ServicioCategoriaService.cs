namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class ServicioCategoriaService(
    IServicioCategoriaRepository staticServicioCategoriaRepository,
    ILogger<ServicioCategoriaService> logger) : IServiceCategoryService {
    public async Task<Result<IEnumerable<ServicioCategoria>?>> GetAllAsync() {
        try {
            var servicios = await staticServicioCategoriaRepository.GetAllAsync();
            return !servicios.Any() ?
                Result<IEnumerable<ServicioCategoria>?>.Success(null) :
                Result<IEnumerable<ServicioCategoria>?>.Success(servicios);
        }
        catch (Exception ex) {
            var error = new Error("GetAllAsync.DatabaseFailure", ex.Message);
            logger.LogCritical(ex, "{ErrorMessage}", error.Message);
            return Result<IEnumerable<ServicioCategoria>?>.Failure(error);
        }
    }

    public async Task<Result<IEnumerable<ServicioCategoria>?>> GetByNombresAsync(IEnumerable<string> nombres) {
        try {
            var servicios = await staticServicioCategoriaRepository.GetByNombresAsync(nombres);
            return (servicios == null || !servicios.Any()) ?
                Result<IEnumerable<ServicioCategoria>?>.Success(null) :
                Result<IEnumerable<ServicioCategoria>?>.Success(servicios);
        }
        catch (Exception ex) {
            var error = new Error("GetByNombresAsync.DatabaseFailure", ex.Message);
            logger.LogCritical(ex, "{ErrorMessage}", error.Message);
            return Result<IEnumerable<ServicioCategoria>?>.Failure(error);
        }
    }
}
