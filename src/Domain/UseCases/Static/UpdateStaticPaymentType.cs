namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class UpdateStaticPaymentType {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public UpdateStaticPaymentType(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Forpago forpagos) {
        var paymentType = forpagos.ToPaymentType();
        return await staticSynchronizerApiClient.UpdatePaymentType(paymentType);
    }
}
