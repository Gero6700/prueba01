namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class CreateStaticPaymentType : ICreateStaticPaymentType {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public CreateStaticPaymentType(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Forpago forpagos) {
        var paymentType = forpagos.ToPaymentType();
        return await staticSynchronizerApiClient.CreatePaymentType(paymentType);
    }
}
