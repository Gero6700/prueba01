namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricingPax;
public interface ICreatePeriodPricingPax {
    Task<HttpResponseMessage> Execute(Condtos condtos);
}
