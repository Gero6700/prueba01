namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
public interface ICreateOfferSupplementGroup {
    Task<HttpResponseMessage> Execute(ConofcomHeader conofcomHeader);
}