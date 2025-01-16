namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface IUpdateStaticTax {
    Task<HttpResponseMessage> Execute(Reszoim reszoim);
}
