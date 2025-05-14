namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IHotelService {
    Task<Result<Hotel?>> GetHotelAsync(int hotelId);
    Task<Result<IEnumerable<Hotel>?>> GetAllAsync();

    Task<Result<IEnumerable<int>?>> GetAllHotelsIdsAsync();
}
