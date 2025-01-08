namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;
public interface ICreateOfferAndSupplementConfigurationPax {
    Task<HttpResponseMessage> Execute(Condtof condtof);
}
