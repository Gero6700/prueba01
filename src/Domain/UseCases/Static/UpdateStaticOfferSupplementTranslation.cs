namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class UpdateStaticOfferSupplementTranslation : IUpdateStaticOfferSupplementTranslation {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public UpdateStaticOfferSupplementTranslation(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Desofer desofer) {
        var offerAndSupplementTranslation = desofer.ToOfferAndSupplementTranslation();
        return await staticSynchronizerApiClient.UpdateOfferSupplementTranslation(offerAndSupplementTranslation);
    }
}
