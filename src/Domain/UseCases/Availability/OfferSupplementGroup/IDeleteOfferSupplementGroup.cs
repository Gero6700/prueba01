namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
public interface IDeleteOfferSupplementGroup {
    Task<HttpResponseMessage> Execute(ConofcomHeader conofcomHeader);
}
