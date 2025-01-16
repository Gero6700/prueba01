namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class UpdateStaticExtraTranslation : IUpdateStaticExtraTranslation {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public UpdateStaticExtraTranslation(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Desextr desextr) {
        var extraTranslation = desextr.ToExtraTranslation();
        return await staticSynchronizerApiClient.UpdateExtraTranslation(extraTranslation);
    }
}
