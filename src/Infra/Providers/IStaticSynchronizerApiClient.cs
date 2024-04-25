namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public interface IStaticSynchronizerApiClient {
    Task<Response> PushHotel(Dtos.BookingCenter.Static.Hotel hotel);
    Task<Response> PushServiceCategories(List<ServiceCategory> serviceCategories);
}
