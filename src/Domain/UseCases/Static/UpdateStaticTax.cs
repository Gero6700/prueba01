namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class UpdateStaticTax : IUpdateStaticTax {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public UpdateStaticTax(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Reszoim reszoim) {
        var tax = reszoim.ToTax();
        return await staticSynchronizerApiClient.UpdateTax(tax);
    }
}
