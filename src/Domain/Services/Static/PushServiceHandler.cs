namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class PushServiceHandler(
    IStaticSynchronizerApiClient staticSynchronizerApiClient,
    IServicioService serviceService,
    ILogger<PushServiceHandler> logger) {

    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient = staticSynchronizerApiClient;
    private readonly IServicioService serviceService = serviceService;
    private readonly ILogger<PushServiceHandler> logger = logger;

    public async Task Execute(CancellationToken stoppingToken) {
        var services = await serviceService.GetAllAsync();
        if (services.IsFailure) {
            return;
        }
        if (services.Value == null) {
            logger.LogError("ServiceService.ServicesNotFound");
            return;
        }
        try {
            var serviceDtos = services.Value.ToServiceDto();
            await Parallel.ForEachAsync(serviceDtos!, async (serviceDto, cancellationToken) => {
                try {
                    var response = await staticSynchronizerApiClient.PushService(serviceDto);
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
