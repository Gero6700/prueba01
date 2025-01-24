namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplement;
public interface IUpdateOfferSupplement {
    Task<HttpResponseMessage> Execute(Conofege conofege);
}
