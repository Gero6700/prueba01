namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IServicioService {
    Task<Result<IEnumerable<Servicio>?>> GetAllAsync();
}
