
namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public class StaticSynchronizerApiClient : IStaticSynchronizerApiClient {
    private readonly HttpClient httpClient;
    
    public StaticSynchronizerApiClient(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public Task<HttpResponseMessage> PushHotel(StaticHotelDto hotel) {
        return httpClient.PutAsJsonAsync("api/v1/hotel/push", hotel);
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
