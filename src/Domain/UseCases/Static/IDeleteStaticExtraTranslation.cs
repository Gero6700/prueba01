namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface IDeleteStaticExtraTranslation {
    Task<HttpResponseMessage> Execute(Desextr desextr);
}
