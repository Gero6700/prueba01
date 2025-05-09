
namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class RegimeService(
    IRegimenRepository staticRegimenRepository,
    ILogger<RegimeService> logger) : IMealService {
    public async Task<Result<IEnumerable<Regimen>?>> GetAllAsync() {
        try {
            var regimen = await staticRegimenRepository.GetAllAsync();
            return !regimen.Any() ?
                Result<IEnumerable<Regimen>?>.Success(null) :
                Result<IEnumerable<Regimen>?>.Success(regimen);
        }
        catch (Exception ex) {
            var error = new Error("GetAllAsync.DatabaseFailure", ex.Message);
            logger.LogCritical(ex, "{ErrorMessage}", error.Message);
            return Result<IEnumerable<Regimen>?>.Failure(error);
        }
    }
}
