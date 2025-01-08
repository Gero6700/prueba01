namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricingPax;
public interface IUpdatePeriodPricingPax {
    Task<HttpResponseMessage> Execute(Condtos condtos);
}
