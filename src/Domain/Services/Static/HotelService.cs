namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class HotelService(
    IStaticHotelRepository staticHotelRepository,
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
}
