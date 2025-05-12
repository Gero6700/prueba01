namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class PushServiceCategoryHandler(
    IStaticSynchronizerApiClient staticSynchronizerApiClient,
    IServicioCategoriaService servicioCategoriaService,
    ILogger<PushServiceCategoryHandler> logger) : IPushServiceCategoryHandler {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient = staticSynchronizerApiClient;
    private readonly IServicioCategoriaService servicioCategoriaService = servicioCategoriaService;
    private readonly ILogger<PushServiceCategoryHandler> logger = logger;

    public async Task Execute(CancellationToken stoppingToken) {
        var servicioCategorias = await servicioCategoriaService.GetAllAsync();
        if (servicioCategorias.IsFailure) {
            return;
        }
        if (servicioCategorias.Value == null) {
            logger.LogError("ServiceCategoryService.ServicesNotFound");
            return;
        }
        try {
            var serviceCategoryDtos = servicioCategorias.Value.ToServiceCategoryDto();
            var parallelOptions = new ParallelOptions {
                MaxDegreeOfParallelism = 8, 
                CancellationToken = stoppingToken
            };
            await Parallel.ForEachAsync(serviceCategoryDtos!, parallelOptions, async (serviceDto, cancellationToken) => {
                try {
                    var response = await staticSynchronizerApiClient.PushServiceCategory(serviceDto);
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
