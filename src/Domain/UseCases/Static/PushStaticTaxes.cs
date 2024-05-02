namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticTaxes {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticTaxes(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(List<Reszoim> reszoims) {
        var taxes = reszoims.Select(x => x.ToTax()).ToList();
        await staticSynchronizerApiClient.PushTaxes(taxes);
    }
}
