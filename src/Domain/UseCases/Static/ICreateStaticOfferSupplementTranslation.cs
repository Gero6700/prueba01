namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface ICreateStaticOfferSupplementTranslation {
    Task<HttpResponseMessage> Execute(Desofer desofer);
}
