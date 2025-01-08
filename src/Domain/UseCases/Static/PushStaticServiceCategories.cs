namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticServiceCategories {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticServiceCategories(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(List<EstServicioCategoria> estServicioCategorias) {
        var serviceCategories = estServicioCategorias.Select(estServicioCategoria => estServicioCategoria.ToServiceCategory()).ToList();
        return await staticSynchronizerApiClient.PushServiceCategories(serviceCategories);
    }
}
