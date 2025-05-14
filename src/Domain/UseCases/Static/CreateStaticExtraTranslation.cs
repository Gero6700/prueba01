namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class CreateStaticExtraTranslation {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public CreateStaticExtraTranslation(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Desextr desextr) {
        var extraTranslation = desextr.ToExtraTranslation();
        return await staticSynchronizerApiClient.CreateExtraTranslation(extraTranslation);
    }
}
