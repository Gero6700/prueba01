namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class DeleteStaticPaymentType : IDeleteStaticPaymentType {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public DeleteStaticPaymentType(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(Forpago forpago) {
        var paymentType = forpago.ToPaymentType();
        return await staticSynchronizerApiClient.DeletePaymentType(paymentType.Code);
    }
}
