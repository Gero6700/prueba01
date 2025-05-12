
namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class RegimenService(
    IRegimenRepository staticRegimenRepository,
    ILogger<RegimenService> logger) : IRegimenService {
    public async Task<Result<IEnumerable<Regimen>?>> GetAllAsync() {
        try {
            var regimenes = await staticRegimenRepository.GetAllAsync();
            return (regimenes == null || !regimenes.Any()) ?
                Result<IEnumerable<Regimen>?>.Success(null) :
                Result<IEnumerable<Regimen>?>.Success(regimenes);
        }
        catch (Exception ex) {
            var error = new Error("GetAllAsync.DatabaseFailure", ex.Message);
            logger.LogCritical(ex, "{ErrorMessage}", error.Message);
            return Result<IEnumerable<Regimen>?>.Failure(error);
        }
    }

    public async Task<Result<IEnumerable<Regimen>?>> GetDistinctCodeAsync() {
        try {
            var regimenes = await staticRegimenRepository.GetAllAsync();
            if (regimenes == null || !regimenes.Any()) {
                return Result<IEnumerable<Regimen>?>.Success(null);
            }

            var distinctRegimenes = regimenes.GroupBy(r => r.Codigo)
                .Select(g => g.First())
                .ToList();

            return distinctRegimenes.Count == 0 ?
                Result<IEnumerable<Regimen>?>.Success(null) :
                Result<IEnumerable<Regimen>?>.Success(distinctRegimenes);
        }
        catch (Exception ex) {
            var error = new Error("GetDistinctCodeAsync.DatabaseFailure", ex.Message);
            logger.LogCritical(ex, "{ErrorMessage}", error.Message);
            return Result<IEnumerable<Regimen>?>.Failure(error);
        }
    }
}
