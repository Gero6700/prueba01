namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;
public interface IUpdateOfferAndSupplementConfigurationPax {
    Task<HttpResponseMessage> Execute(Condtof condtof);
}
