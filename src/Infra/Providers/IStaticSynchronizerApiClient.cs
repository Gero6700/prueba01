namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public interface IStaticSynchronizerApiClient {
    Task<HttpResponseMessage> PushHotel(Dtos.BookingCenter.Static.Hotel hotel);
    Task<HttpResponseMessage> PushServiceCategories(List<ServiceCategory> serviceCategories);
    Task<HttpResponseMessage> PushServices(List<Service> services);
    Task<HttpResponseMessage> PushOffersAndSupplementsTranslations(List<OfferAndSupplementTranslation> offerAndSupplementTranslations);
    Task<HttpResponseMessage> PushExtrasTranslations(List<ExtraTranslation> extraTranslations);
    Task<HttpResponseMessage> PushPaymentTypes(List<PaymentType> paymentTypes);
    Task<HttpResponseMessage> PushRegimes(List<Dtos.BookingCenter.Static.Regime> regimes);
    Task<HttpResponseMessage> PushTaxes(List<Tax> taxes);
}
