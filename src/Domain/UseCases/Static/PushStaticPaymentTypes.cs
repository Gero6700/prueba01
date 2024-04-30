namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticPaymentTypes {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticPaymentTypes(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(List<Forpago> forpagos) {
        var paymentTypes = forpagos.Select(x => x.ToPaymentType()).ToList();
        await staticSynchronizerApiClient.PushPaymentTypes(paymentTypes);
    }
}
