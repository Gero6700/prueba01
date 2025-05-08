
using Senator.As400.Cloud.Sync.Application.Services.Static;

namespace Senator.As400.Cloud.Sync.Api.HostedService;
public class NightlyStaticSyncService(
    IServiceScopeFactory serviceScopeFactory,
    ILogger<NightlyStaticSyncService> logger) 
    : BackgroundService {
    private readonly IServiceScopeFactory serviceScopeFactory = serviceScopeFactory;
    private readonly ILogger<NightlyStaticSyncService> logger = logger;

    protected override Task ExecuteAsync(CancellationToken stoppingToken) {
        while (!stoppingToken.IsCancellationRequested) {
            //Wait to 24:00
            var now = DateTime.UtcNow;
            var nextRun = now.Date.AddDays(1);
            var delay = nextRun - now;

            if (delay.TotalMilliseconds > 0) {
                logger.LogInformation("NightlyStaticSyncService: Waiting for {Delay} to run the sync service", delay);
                Task.Delay(delay, stoppingToken).Wait(stoppingToken);
            }

            using var scope = serviceScopeFactory.CreateScope();
            var syncService = scope.ServiceProvider.GetRequiredService<ISyncService>();
            syncService.SyncAsync(stoppingToken).Wait(stoppingToken);

            try {
                logger.LogInformation("NightlyStaticSyncService: Starting hotel synchronization at {Time}.", DateTime.Now);

                // Consultar todos los hoteles
                var hotelsResult = await hotelService.GetAllHotelsAsync();
                if (!hotelsResult.IsSuccess || hotelsResult.Value == null) {
                    logger.LogError("NightlyHotelSyncService: Failed to retrieve hotels. Error: {Error}", hotelsResult.Error?.Message);
                    continue;
                }

                var hotels = hotelsResult.Value;

                // Enviar cada hotel a la API de sincronización
                foreach (var hotel in hotels) {
                    var response = await apiClient.PushHotel(hotel);
                    if (!response.IsSuccessStatusCode) {
                        logger.LogError("NightlyStaticSyncService: Failed to sync hotel {HotelId}. StatusCode: {StatusCode}", hotel.Id, response.StatusCode);
                    }
                    else {
                        logger.LogInformation("NightlyStaticSyncService: Successfully synced hotel {HotelId}.", hotel.Id);
                    }
                }
            }
            catch (Exception ex) {
                logger.LogError(ex, "NightlyStaticSyncService: An error occurred during static synchronization.");
            }

        }
    }
}
