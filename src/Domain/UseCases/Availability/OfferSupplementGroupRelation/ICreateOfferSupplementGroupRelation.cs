namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroupOfferAndSupplement;
public  interface ICreateOfferSupplementGroupRelation {
    Task<HttpResponseMessage> Execute(ConofcomLine conofcomLine);
}
