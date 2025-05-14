namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class DeleteStaticExtraTranslation {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public DeleteStaticExtraTranslation(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Desextr desextr) {
        var extraTranslation = desextr.ToExtraTranslation();
        return await staticSynchronizerApiClient.DeleteExtraTranslation(extraTranslation.ExtraCode);
    }
}
