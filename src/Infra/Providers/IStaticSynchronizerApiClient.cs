namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public interface IStaticSynchronizerApiClient {
    Task<Response> PushHotel(Dtos.BookingCenter.Static.Hotel hotel);
    Task<Response> PushServiceCategories(List<ServiceCategory> serviceCategories);
    Task<Response> PushServices(List<Service> services);
    Task<Response> PushOffersAndSupplementsTranslations(List<OfferAndSupplementTranslation> offerAndSupplementTranslations);
    Task<Response> PushExtrasTranslations(List<ExtraTranslation> extraTranslations);
}
