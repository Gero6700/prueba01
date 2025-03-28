using Senator.As400.Cloud.Sync.Infrastructure.Domain.Abstractions.Persistence;
using Senator.As400.Cloud.Sync.Infrastructure.Domain.Entities;

namespace Senator.As400.Cloud.Sync.Infrastructure.Domain.Repositories;
public interface IStaticHotelRepository : IRepository<Hotel> {
    Task<Hotel?> GetHotelAsync(int hotelId);
}
