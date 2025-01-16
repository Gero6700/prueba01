namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface IDeleteStaticPaymentType {
    Task<HttpResponseMessage> Execute(Forpago forpago);
}
