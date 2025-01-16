namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface ICreateStaticTax {
    Task<HttpResponseMessage> Execute(Reszoim reszoim);
}
