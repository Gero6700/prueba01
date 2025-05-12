namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class PushHotelServiceHandler(
    IStaticSynchronizerApiClient staticSynchronizerApiClient,
    IHotelService hotelService,
    ILogger<PushHotelServiceHandler> logger) : IPushHotelServiceHandler {

    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient = staticSynchronizerApiClient;
    private readonly IHotelService hotelService = hotelService;
    private readonly ILogger<PushHotelServiceHandler> logger = logger;

    public async Task Execute(CancellationToken stoppingToken) {
        var hotels = await hotelService.GetAllAsync();
        if (hotels.IsFailure) {
            return;
        }
        if (hotels.Value == null) {
            logger.LogError("HotelService.HotelsNotFound");
            return;
        }
        try {
            var hotelDtos = hotels.Value.ToHotelDtos();
            var parallelOptions = new ParallelOptions {
                MaxDegreeOfParallelism = 8,
                CancellationToken = stoppingToken
            };
            await Parallel.ForEachAsync(hotelDtos!, parallelOptions, async (hotelDto, cancellationToken) => {
                try {
                    var response = await staticSynchronizerApiClient.PushHotel(hotelDto);
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
