namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroupOfferAndSupplement;
public interface IDeleteOfferSupplementGroupRelation {
    public Task<HttpResponseMessage> Execute(ConofcomLine conofcomLine);
}
