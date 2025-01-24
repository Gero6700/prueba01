namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;
public interface IDeleteOfferSupplementConfigurationPax {
    Task<HttpResponseMessage> Execute(string code);
}
