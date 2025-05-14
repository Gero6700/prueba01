namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class PushHotelServiceHandler(
    IStaticSynchronizerApiClient staticSynchronizerApiClient,
    IHotelService hotelService,
    ILogger<PushHotelServiceHandler> logger) : IPushHotelServiceHandler {

    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient = staticSynchronizerApiClient;
    private readonly IHotelService hotelService = hotelService;
    private readonly ILogger<PushHotelServiceHandler> logger = logger;

    public async Task Execute(CancellationToken stoppingToken) {
      try {
            var hotelsIds = await hotelService.GetAllHotelsIdsAsync();
            if (hotelsIds.IsFailure) {
                return;
            }
            if (hotelsIds.Value == null) {
                logger.LogError("HotelService.HotelsNotFound");
                return;
            }

            var hotelIds = hotelsIds.Value.ToList();
            var hotels = new List<Hotel>();
            foreach (var hotelId in hotelIds) {
                var hotel = await hotelService.GetHotelAsync(hotelId);
                if (hotel.IsFailure) {
                    logger.LogError("HotelService.HotelNotFound");
                    continue;
                }
                if (hotel.Value == null) {
                    logger.LogError("HotelService.HotelNotFound");
                    continue;
                }
                hotels.Add(hotel.Value);
            }

            var parallelOptions = new ParallelOptions {
                MaxDegreeOfParallelism = 10,
                CancellationToken = stoppingToken
            };
            await Parallel.ForEachAsync(hotels!, parallelOptions, async (hotel, cancellationToken) => {
                try {
                    var hotelDto = hotel.ToHotelDto();  
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
