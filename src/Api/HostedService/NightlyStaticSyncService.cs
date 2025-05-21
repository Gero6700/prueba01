namespace Senator.As400.Cloud.Sync.Api.HostedService;
public class NightlyStaticSyncService(
    IServiceScopeFactory serviceScopeFactory,
    ILogger<NightlyStaticSyncService> logger) 
    : BackgroundService {
    private readonly IServiceScopeFactory serviceScopeFactory = serviceScopeFactory;
    private readonly ILogger<NightlyStaticSyncService> logger = logger;

    private static readonly SemaphoreSlim Semaphore = new(1, 1);
    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        try {
            while (!stoppingToken.IsCancellationRequested) {
                await Semaphore.WaitAsync(stoppingToken);

                //Wait to 24:00
                var now = DateTime.Now;
                var nextRun = now.Date.AddDays(1);
                var delay = nextRun - now;

                if (delay.TotalMilliseconds > 0) {
                    logger.LogInformation("NightlyStaticSyncService: Waiting for {Delay} to run the sync service", delay);
                    await Task.Delay(delay, stoppingToken);
                }

                try {
                    logger.LogInformation("NightlyStaticSyncService: Starting synchronization at {Time}", DateTime.UtcNow);
                    await ExecuteSync(stoppingToken);
                    logger.LogInformation("NightlyStaticSyncService: Synchronization completed at {Time}", DateTime.UtcNow);
                }
                catch (Exception ex) {
                    logger.LogError(ex, "NightlyStaticSyncService: An error occurred during synchronization.");
                }
                finally {
                    Semaphore.Release();
                }
            }
        }
        catch (Exception ex) {
            logger.LogError(ex, "NightlyStaticSyncService: An error occurred in the background service.");
        }        
    }

    private async Task ExecuteSync(CancellationToken stoppingToken) {
        using var scope = serviceScopeFactory.CreateScope();
        var pushServiceHandler = scope.ServiceProvider.GetRequiredService<IPushServiceHandler>();
        var pushMealServiceHandler = scope.ServiceProvider.GetRequiredService<IPushMealServiceHandler>();
        var pushServiceCategoryHandler = scope.ServiceProvider.GetRequiredService<IPushServiceCategoryHandler>();
        var pushHotelServiceHandler = scope.ServiceProvider.GetRequiredService<IPushHotelServiceHandler>();

        await pushServiceCategoryHandler.Execute(stoppingToken);
        await pushServiceHandler.Execute(stoppingToken);
        await pushMealServiceHandler.Execute(stoppingToken);
        await pushHotelServiceHandler.Execute(stoppingToken);
    }
}
