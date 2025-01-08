namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricing;
public interface IUpdatePeriodPricing {
    Task<HttpResponseMessage> Execute(Conpreci conpreci);
}
