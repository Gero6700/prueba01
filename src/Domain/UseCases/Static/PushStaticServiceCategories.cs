namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticServiceCategories {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticServiceCategories(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(List<EstServicioCategoria> estServicioCategorias) {
        var serviceCategories = estServicioCategorias.Select(estServicioCategoria => estServicioCategoria.ToServiceCategory()).ToList();
        await staticSynchronizerApiClient.PushServiceCategories(serviceCategories);
    }
}
