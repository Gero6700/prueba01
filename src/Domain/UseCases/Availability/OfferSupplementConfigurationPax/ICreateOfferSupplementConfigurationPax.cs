namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;
public interface ICreateOfferSupplementConfigurationPax {
    Task<HttpResponseMessage> Execute(Condtof condtof);
}
