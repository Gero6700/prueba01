namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Regime;
public interface IUpdateRegimen {
    Task<HttpResponseMessage> Execute(Restregi restregi);
}
