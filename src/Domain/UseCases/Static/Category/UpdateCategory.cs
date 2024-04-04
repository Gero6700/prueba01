namespace Senator.As400.Cloud.Sync.Application.UseCases.Static.Category;
public class UpdateCategory {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    
    public UpdateCategory(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(MarcaComercial marcaComercial) {
        if (marcaComercial.Id == 0) {
            throw new ArgumentException("Category code is required");
        }
        var category = marcaComercial.ToCategory();
        await staticSynchronizerApiClient.UpdateCategory(category);
    }
}
