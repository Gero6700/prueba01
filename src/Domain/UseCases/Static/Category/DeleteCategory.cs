namespace Senator.As400.Cloud.Sync.Application.UseCases.Static.Category;
public class DeleteCategory {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public DeleteCategory(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(int id) {
        await staticSynchronizerApiClient.DeleteCategory(id.ToString());
    }
}
