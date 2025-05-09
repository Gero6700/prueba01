
using Senator.As400.Cloud.Sync.Infrastructure.Persistence.Repositories;

namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class ServicioService(
    IServicioRepository servicioRepository,
    ILogger<ServicioService> logger) : IServicioService {
    public async Task<Result<IEnumerable<Servicio>?>> GetAllAsync() {
        try {
            var servicios = await servicioRepository.GetAllAsync();
            return !servicios.Any() ? 
                Result<IEnumerable<Servicio>?>.Success(null) :
                Result<IEnumerable<Servicio>?>.Success(servicios);
        }
        catch (Exception ex) {
            var error = new Error("GetAllAsync.DatabaseFailure", ex.Message);
            logger.LogCritical(ex, "{ErrorMessage}", error.Message);
            return Result<IEnumerable<Servicio>?>.Failure(error);
        }
    }

    //public async Task<Result<IEnumerable<StaticEquipmentDto>?>> GetByNombresAsync(IEnumerable<string> nombres) {
    //    try {
    //        IEnumerable<string> nombres = ["habitación", "habitaciones"];
    //        var categorias = await servicioCategoriaRepository.GetByNombresAsync(nombres);
    //        if (categorias == null || !categorias.Any()) {
    //            return Result<IEnumerable<StaticEquipmentDto>?>.Success(null);
    //        }

    //        var servicios = await servicioRepository.GetAllAsync();
    //        var equipments = servicios.Where(s => categorias.Any(c => c.Id == s.IdCategoria));

    //        return !servicios.Any() ?
    //            Result<IEnumerable<StaticEquipmentDto>?>.Success(null) :
    //            Result<IEnumerable<StaticEquipmentDto>?>.Success(servicios.ToEquipmentDto());
    //    }
    //    catch (Exception ex) {
    //        var error = new Error("GetAllAsync.DatabaseFailure", ex.Message);
    //        logger.LogCritical(ex, "{ErrorMessage}", error.Message);
    //        return Result<IEnumerable<StaticEquipmentDto>?>.Failure(error);
    //    }
    //}
}
