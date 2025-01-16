namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public interface IUpdateStaticExtraTranslation {
    Task<HttpResponseMessage> Execute(Desextr desextr);
}
