namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class DeleteStaticTax : IDeleteStaticTax {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public DeleteStaticTax(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Reszoim reszoim) {
        var tax = reszoim.ToTax();
        return await staticSynchronizerApiClient.DeleteTax(tax);
    }
}
