namespace Senator.As400.Cloud.Sync.Domain.Repositories;
public interface IHotelRepository : IRepository<Hotel> {
    Task<Hotel?> GetHotelAsync(int hotelId);
    Task<IEnumerable<int>?> GetAllHotelsIdsAsync();
}
