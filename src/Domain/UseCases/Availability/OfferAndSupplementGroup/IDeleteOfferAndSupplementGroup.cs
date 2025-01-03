namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
public interface IDeleteOfferAndSupplementGroup {
    Task Execute(ConofcomHeader conofcomHeader);
}
