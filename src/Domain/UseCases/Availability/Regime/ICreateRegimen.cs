namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Regime;
public interface ICreateRegimen {
    Task<HttpResponseMessage> Execute(Restregi restregi);
}
