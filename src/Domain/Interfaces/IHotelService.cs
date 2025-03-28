using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;

namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IHotelService {
    Task<StaticHotelDto?> GetHotelAsync(int hotelId);
}
