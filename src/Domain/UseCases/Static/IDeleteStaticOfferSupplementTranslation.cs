namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface IDeleteStaticOfferSupplementTranslation {
    Task<HttpResponseMessage> Execute(Desofer desofer);
}
