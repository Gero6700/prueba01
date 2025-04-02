namespace Senator.As400.Cloud.Sync.Application.Services.Static;
public class HotelService(
    IUnitOfWork unitOfWork,
    IStaticHotelRepository staticHotelRepository,
    ILogger<HotelService> logger) : IHotelService  {

    public async Task<StaticHotelDto?> GetHotelAsync(int hotelId) {
        try {
            unitOfWork.BeginTransaction();
            var hotel = await staticHotelRepository.GetHotelAsync(hotelId);
            unitOfWork.Commit();
            return hotel?.ToHotelDto();
        }
        catch (Exception ex) {
            unitOfWork.Rollback();
            //var error = CreateMinimumStayCommandErrors.DatabaseFailure;
            //var methodParameters =
            //    $"[MinimumStayCode: {request.MinimumStay.Code} - HotelChainId: {request.HotelChainId}]";
            //logger.LogCritical(ex, "{ErrorMessage} {MethodParameters}", error.Message, methodParameters);
            return null;
        }
    }
}
