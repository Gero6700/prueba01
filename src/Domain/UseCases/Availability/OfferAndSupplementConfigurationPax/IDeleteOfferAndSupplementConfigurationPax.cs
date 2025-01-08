namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;
public interface IDeleteOfferAndSupplementConfigurationPax {
    Task<HttpResponseMessage> Execute(string code);
}
