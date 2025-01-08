namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticPaymentTypes {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticPaymentTypes(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(List<Forpago> forpagos) {
        var paymentTypes = forpagos.Select(x => x.ToPaymentType()).ToList();
        return await staticSynchronizerApiClient.PushPaymentTypes(paymentTypes);
    }
}
