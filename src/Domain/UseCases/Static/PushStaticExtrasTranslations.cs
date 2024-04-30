namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticExtrasTranslations {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticExtrasTranslations(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(List<Desextr> desextrs) {
        var extrasTranslations = desextrs.Select(x => x.ToExtraTranslation()).ToList();
        await staticSynchronizerApiClient.PushExtrasTranslations(extrasTranslations);
    }
}
