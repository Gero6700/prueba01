namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IHotelService {
    Task<Result<StaticHotelDto?>> GetHotelAsync(int hotelId);
    Task<Result<IEnumerable<Hotel>?>> GetAllAsync();
}
