namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface ICreateStaticExtraTranslation {
    Task<HttpResponseMessage> Execute(Desextr desextr);
}