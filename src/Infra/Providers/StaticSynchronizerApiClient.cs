
using System.Net.Http.Json;
using Senator.As400.Cloud.Sync.Infrastructure.Dtos.BookingCenter.Static;

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
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreateOfferSupplementTranslation(StaticOfferAndSupplementTranslation offerAndSupplementTranslation) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreatePaymentType(PaymentType paymentType) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreateTax(StaticTax tax) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.DeleteExtraTranslation(string extraCode, string languageIsoCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.DeleteOfferSupplementTranslation(string offerAndSupplementCode, string languageIsoCode) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.DeletePaymentType(string code) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.DeleteTax(StaticTax tax) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdateExtraTranslation(StaticExtraTranslationDto extraTranslations) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdateOfferSupplementTranslation(StaticOfferAndSupplementTranslation offerAndSupplementTranslation) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdatePaymentType(PaymentType paymentType) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdateTax(StaticTax tax) {
        throw new NotImplementedException();
    }
}
