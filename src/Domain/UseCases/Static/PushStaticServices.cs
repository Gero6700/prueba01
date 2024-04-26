namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticServices {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticServices(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(List<EstServicio> estServicios) {
        var services = estServicios.Select(estServicio => estServicio.ToService()).ToList();
        await staticSynchronizerApiClient.PushServices(services);
    }

}
