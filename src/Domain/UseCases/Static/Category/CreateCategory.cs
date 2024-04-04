namespace Senator.As400.Cloud.Sync.Application.UseCases.Static.Category;
public class CreateCategory {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public CreateCategory(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(MarcaComercial marcaComercial) {
        var category = marcaComercial.ToCategory();
        await staticSynchronizerApiClient.CreateCategory(category);
    }
}
