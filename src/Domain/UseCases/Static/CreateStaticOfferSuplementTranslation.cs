namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class CreateStaticOfferSuplementTranslation {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public CreateStaticOfferSuplementTranslation(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Desofer desofer) {
        var offerAndSupplementTranslation = desofer.ToOfferAndSupplementTranslation();
        return await staticSynchronizerApiClient.CreateOfferSupplementTranslation(offerAndSupplementTranslation);
    }
}
