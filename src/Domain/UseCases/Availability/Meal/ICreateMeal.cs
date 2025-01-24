namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Regime;
public interface ICreateMeal {
    Task<HttpResponseMessage> Execute(Restregi restregi);
}
