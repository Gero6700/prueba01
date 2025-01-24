namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;
public interface IUpdateOfferSupplementConfigurationPax {
    Task<HttpResponseMessage> Execute(Condtof condtof);
}
