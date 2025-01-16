namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface IUpdateStaticPaymentType {
    Task<HttpResponseMessage> Execute(Forpago forpago);
}
