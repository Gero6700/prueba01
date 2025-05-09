namespace Senator.As400.Cloud.Sync.Infrastructure.Persistence.Repositories;
public class RegimenRepository(IUnitOfWork unitOfWork) 
    : Repository<Regimen>(unitOfWork), IRegimenRepository;
