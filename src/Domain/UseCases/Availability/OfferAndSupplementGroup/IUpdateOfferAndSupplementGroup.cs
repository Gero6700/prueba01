namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
public interface IUpdateOfferAndSupplementGroup {
    Task Execute(ConofcomHeader conofcomHeader);
}