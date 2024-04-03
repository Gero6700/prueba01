using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
public class DeleteOfferAndSupplementGroup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteOfferAndSupplementGroup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(ConofcomHeader conofcomHeader) {
        if (conofcomHeader.Occin == 0) {
            throw new ArgumentException("Group code is zero");
        }
        var offerAndSupplementGroup = conofcomHeader.ToOfferAndSupplementGroup();
        await availabilitySynchronizerApiClient.DeleteOfferAndSupplementGroup(offerAndSupplementGroup.Code);
    }
}
