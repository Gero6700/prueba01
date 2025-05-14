namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class DeleteStaticOfferSupplementTranslation {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public DeleteStaticOfferSupplementTranslation(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Desofer desofer) {
        var offerAndSupplementTranslation = desofer.ToOfferAndSupplementTranslation();
        return await staticSynchronizerApiClient.DeleteOfferSupplementTranslation(offerAndSupplementTranslation.OfferAndSupplementCode);
    }
}
