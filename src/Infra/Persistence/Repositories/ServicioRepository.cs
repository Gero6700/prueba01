
namespace Senator.As400.Cloud.Sync.Infrastructure.Persistence.Repositories;
public class ServicioRepository(IUnitOfWork unitOfWork)
    : Repository<Servicio>(unitOfWork), IServicioRepository;
