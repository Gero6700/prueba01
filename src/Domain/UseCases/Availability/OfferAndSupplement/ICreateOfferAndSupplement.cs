namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplement;
public interface ICreateOfferAndSupplement {
    Task<HttpResponseMessage> Execute(Conofege conofege);
}
