namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class PushMealServiceHandler(
    IStaticSynchronizerApiClient staticSynchronizerApiClient,
    IRegimenService regimenService,
    ILogger<PushMealServiceHandler> logger) : IPushMealServiceHandler {

    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient = staticSynchronizerApiClient;
    private readonly IRegimenService regimenService = regimenService;
    private readonly ILogger<PushMealServiceHandler> logger = logger;

    public async Task Execute(CancellationToken stoppingToken) {
        var regimenes = await regimenService.GetDistinctCodeAsync();
        if (regimenes.IsFailure) {
            return;
        }
        if (regimenes.Value == null) {
            logger.LogError("RegimenService.MealsNotFound");
            return;
        }
        try {
            var mealsDtos = regimenes.Value.ToMealDto();
            var parallelOptions = new ParallelOptions {
                MaxDegreeOfParallelism = 8,
                CancellationToken = stoppingToken
            };
            await Parallel.ForEachAsync(mealsDtos!, parallelOptions, async (mealDto, cancellationToken) => {
                try {
                    var response = await staticSynchronizerApiClient.PushMeal(mealDto);
                    if (!response.IsSuccessStatusCode) {
                        var content = await response.Content.ReadAsStringAsync(cancellationToken);
                        logger.LogError("StaticSynchronizerApiClientError: {Content}", content);
                    }
                }
                catch (Exception ex) {
                    logger.LogError("{ErrorMessage}", ex.Message);
                }
            });
        }
        catch (Exception ex) {
            logger.LogError("{ErrorMessage}", ex.Message);
        }
    }

}
