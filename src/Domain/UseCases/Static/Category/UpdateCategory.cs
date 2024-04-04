namespace Senator.As400.Cloud.Sync.Application.UseCases.Static.Category;
public class UpdateCategory {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    
    public UpdateCategory(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(MarcaComercial marcaComercial) {
        var category = marcaComercial.ToCategory();
        await staticSynchronizerApiClient.UpdateCategory(category);
    }
}
