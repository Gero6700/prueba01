namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class CreateStaticTax : ICreateStaticTax {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public CreateStaticTax(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Reszoim reszoim) {
        var tax = reszoim.ToTax();
        return await staticSynchronizerApiClient.CreateTax(tax);
    }
}
