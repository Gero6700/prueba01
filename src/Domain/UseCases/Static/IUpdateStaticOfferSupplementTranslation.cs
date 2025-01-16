namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface IUpdateStaticOfferSupplementTranslation {
    Task<HttpResponseMessage> Execute(Desofer desofer);
}
