namespace Senator.As400.Cloud.Sync.Infrastructure.Providers;
public interface IStaticSynchronizerApiClient {
    Task<HttpResponseMessage> PushHotel(StaticHotelDto hotel);
    Task<HttpResponseMessage> CreateOfferSupplementTranslation(StaticOfferAndSupplementTranslation offerAndSupplementTranslation);
    Task<HttpResponseMessage> UpdateOfferSupplementTranslation(StaticOfferAndSupplementTranslation offerAndSupplementTranslation);
    Task<HttpResponseMessage> DeleteOfferSupplementTranslation(string offerAndSupplementCode);
    Task<HttpResponseMessage> CreateExtraTranslation(StaticExtraTranslationDto extraTranslations);
    Task<HttpResponseMessage> UpdateExtraTranslation(StaticExtraTranslationDto extraTranslations);
    Task<HttpResponseMessage> DeleteExtraTranslation(string extraCode);
    Task<HttpResponseMessage> CreatePaymentType(PaymentType paymentType);
    Task<HttpResponseMessage> UpdatePaymentType(PaymentType paymentType);
    Task<HttpResponseMessage> DeletePaymentType(string code);
    Task<HttpResponseMessage> CreateTax(StaticTax tax);
    Task<HttpResponseMessage> UpdateTax(StaticTax tax);
}
