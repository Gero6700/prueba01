namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
public interface ICreateOfferAndSupplementGroup {
    Task<HttpResponseMessage> Execute(ConofcomHeader conofcomHeader);
}