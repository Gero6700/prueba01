namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface IDeleteStaticTax {
    Task<HttpResponseMessage> Execute(Reszoim reszoim);
}
