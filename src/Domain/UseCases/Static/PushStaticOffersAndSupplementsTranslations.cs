namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticOffersAndSupplementsTranslations {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticOffersAndSupplementsTranslations(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(List<Desofer> desofers) {
        var offersAndSupplementsTranslations = desofers.Select(desofer => desofer.ToOfferAndSupplementTranslation()).ToList();
        return await staticSynchronizerApiClient.PushOffersAndSupplementsTranslations(offersAndSupplementsTranslations);
    }
}
