namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public interface IStaticSynchronizerApiClient {
    Task<HttpResponseMessage> PushHotel(StaticHotelDto hotel);
    Task<HttpResponseMessage> CreateOfferSupplementTranslation(OfferAndSupplementTranslation offerAndSupplementTranslation);
    Task<HttpResponseMessage> UpdateOfferSupplementTranslation(OfferAndSupplementTranslation offerAndSupplementTranslation);
    Task<HttpResponseMessage> DeleteOfferSupplementTranslation(string offerAndSupplementCode, string languageIsoCode);
    Task<HttpResponseMessage> CreateExtraTranslation(ExtraTranslation extraTranslations);
    Task<HttpResponseMessage> UpdateExtraTranslation(ExtraTranslation extraTranslations);
    Task<HttpResponseMessage> DeleteExtraTranslation(string extraCode, string languageIsoCode);
    Task<HttpResponseMessage> CreatePaymentType(PaymentType paymentType);
    Task<HttpResponseMessage> UpdatePaymentType(PaymentType paymentType);
    Task<HttpResponseMessage> DeletePaymentType(string code);
    Task<HttpResponseMessage> CreateTax(Tax tax);
    Task<HttpResponseMessage> UpdateTax(Tax tax);
    Task<HttpResponseMessage> DeleteTax(Tax tax);
}
