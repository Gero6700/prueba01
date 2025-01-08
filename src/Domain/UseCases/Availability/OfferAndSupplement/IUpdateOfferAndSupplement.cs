namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplement;
public interface IUpdateOfferAndSupplement {
    Task<HttpResponseMessage> Execute(Conofege conofege);
}
