
namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public class StaticSynchronizerApiClient : IStaticSynchronizerApiClient {
    private readonly HttpClient httpClient;
    
    public StaticSynchronizerApiClient(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public Task<HttpResponseMessage> PushEquipment(StaticEquipmentDto equipment) {
        return httpClient.PostAsJsonAsync("api/v1/equipment/push", equipment);
    }

    public Task<HttpResponseMessage> PushHotel(StaticHotelDto hotel) {
        return httpClient.PostAsJsonAsync("api/v1/hotel/push", hotel);
    }

    public Task<HttpResponseMessage> PushMeal(StaticMealDto meal) {
        return httpClient.PostAsJsonAsync("api/v1/meal/push", meal);
    }

    public Task<HttpResponseMessage> PushService(StaticServiceDto service) {
        return httpClient.PostAsJsonAsync("api/v1/service/push", service);
    }

    public Task<HttpResponseMessage> PushServiceCategory(StaticServiceCategoryDto serviceCategory) {
        return httpClient.PostAsJsonAsync("api/v1/servicecategory/push", serviceCategory);
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreateExtraTranslation(StaticExtraTranslationDto extraTranslation) {
        return httpClient.PutAsJsonAsync("api/v1/extratranslation/create", extraTranslation);
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreateOfferSupplementTranslation(StaticOfferAndSupplementTranslation offerAndSupplementTranslation) {
        return httpClient.PutAsJsonAsync("api/v1/offersupplementtranslation/create", offerAndSupplementTranslation);
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreatePaymentType(PaymentType paymentType) {
        return httpClient.PutAsJsonAsync("api/v1/paymenttype/create", paymentType);
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreateTax(StaticTax tax) {
        return httpClient.PutAsJsonAsync("api/v1/tax/create", tax);
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.DeleteExtraTranslation(string extraCode) {
        return httpClient.DeleteAsync($"api/v1/extratranslation/delete/{extraCode}");
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.DeleteOfferSupplementTranslation(string offerAndSupplementCode) {
        return httpClient.DeleteAsync($"api/v1/offersupplementtranslation/delete/{offerAndSupplementCode}");
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.DeletePaymentType(string code) {
        return httpClient.DeleteAsync($"api/v1/paymenttype/delete/{code}");
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdateExtraTranslation(StaticExtraTranslationDto extraTranslations) {
        return httpClient.PutAsJsonAsync("api/v1/extratranslation/update", extraTranslations);
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdateOfferSupplementTranslation(StaticOfferAndSupplementTranslation offerAndSupplementTranslation) {
        return httpClient.PutAsJsonAsync("api/v1/offersupplementtranslation/update", offerAndSupplementTranslation);
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdatePaymentType(PaymentType paymentType) {
        return httpClient.PutAsJsonAsync("api/v1/paymenttype/update", paymentType);
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdateTax(StaticTax tax) {
        return httpClient.PutAsJsonAsync("api/v1/tax/update", tax);
    }
}
