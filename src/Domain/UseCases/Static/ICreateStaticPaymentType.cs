namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface ICreateStaticPaymentType {
    Task<HttpResponseMessage> Execute(Forpago forpago);
}
