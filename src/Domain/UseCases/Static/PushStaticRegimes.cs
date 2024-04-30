namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticRegimes {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticRegimes(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute (List<EstRegimen> estRegimenes) {
        var regimes = estRegimenes.Select(x => x.ToRegime()).ToList();
        await staticSynchronizerApiClient.PushRegimes(regimes);
    }
}
