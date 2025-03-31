
using System.Net.Http.Json;

namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public class StaticSynchronizerApiClient : IStaticSynchronizerApiClient {
    private readonly HttpClient httpClient;
    
    public StaticSynchronizerApiClient(HttpClient httpClient) {
        this.httpClient = httpClient;
    }

    public Task<HttpResponseMessage> PushHotel(StaticHotelDto hotel) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreateExtraTranslation(ExtraTranslation extraTranslation) {
        return httpClient.PutAsJsonAsync("api/v1/extratranslation/create", extraTranslation);
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreateOfferSupplementTranslation(OfferAndSupplementTranslation offerAndSupplementTranslation) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreatePaymentType(PaymentType paymentType) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.CreateTax(Tax tax) {
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

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.DeleteTax(Tax tax) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdateExtraTranslation(ExtraTranslation extraTranslations) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdateOfferSupplementTranslation(OfferAndSupplementTranslation offerAndSupplementTranslation) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdatePaymentType(PaymentType paymentType) {
        throw new NotImplementedException();
    }

    Task<HttpResponseMessage> IStaticSynchronizerApiClient.UpdateTax(Tax tax) {
        throw new NotImplementedException();
    }
}
