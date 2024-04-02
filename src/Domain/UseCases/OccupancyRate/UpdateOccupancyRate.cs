namespace Senator.As400.Cloud.Sync.Application.UseCases.OcuppanceRate;
public class UpdateOccupancyRate {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOccupancyRate(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthaco resthaco) {
        if (string.IsNullOrWhiteSpace(resthaco.Cocod)) {
            throw new ArgumentException("Code is required");
        }
        if (resthaco.Cmaxad < resthaco.Cminad) {
            throw new ArgumentException("Max adult is less than min adult");
        }
        if (resthaco.Cmaxat < resthaco.Cminat) {
            throw new ArgumentException("Max teen is less than min teen");
        }
        if (resthaco.Cmaxni < resthaco.Cminni) {
            throw new ArgumentException("Max child is less than min child");
        }
        if (resthaco.Cmaxin < resthaco.Cminin) {
            throw new ArgumentException("Max infant is less than min infant");
        }
        var occuppancyRate = resthaco.ToOccupancyRate();
        await availabilitySynchronizerApiClient.UpdateOccupancyRate(occuppancyRate);
    }
}
