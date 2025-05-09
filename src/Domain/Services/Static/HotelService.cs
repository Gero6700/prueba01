namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class HotelService(
    IHotelRepository staticHotelRepository,
    ILogger<HotelService> logger) : IHotelService  {

    public async Task<Result<StaticHotelDto?>> GetHotelAsync(int hotelId) {
        try {
            var hotel = await staticHotelRepository.GetHotelAsync(hotelId);
            return Result<StaticHotelDto?>.Success(hotel?.ToHotelDto());
        }
        catch (Exception ex) {
            var error = new Error("GetHotelAsync.DatabaseFailure", ex.Message);
            var methodParameters =
                $"[HotelId: {hotelId} ]";
            logger.LogCritical(ex, "{ErrorMessage} {MethodParameters}", error.Message, methodParameters);
            return Result<StaticHotelDto?>.Failure(error);
        }
    }

    public async Task<Result<IEnumerable<int>?>> GetAllHotelsIdsAsync() {
        try {
            var hotelsIds = await staticHotelRepository.GetAllHotelsIdsAsync();
            return Result<IEnumerable<int>?>.Success(hotelsIds);
        }
        catch (Exception ex) {
            var error = new Error("GetAllHotelsIdsAsync.DatabaseFailure", ex.Message);
            logger.LogCritical(ex, "{ErrorMessage}", error.Message);
            return Result<IEnumerable<int>?>.Failure(error);
        }
    }
}
