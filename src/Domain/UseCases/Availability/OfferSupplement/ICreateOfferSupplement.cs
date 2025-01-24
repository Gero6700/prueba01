namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplement;
public interface ICreateOfferSupplement {
    Task<HttpResponseMessage> Execute(Conofege conofege);
}
