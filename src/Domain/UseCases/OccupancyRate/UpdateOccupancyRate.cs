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
        var occuppancyRate = resthaco.ToOccupancyRate();
        await availabilitySynchronizerApiClient.UpdateOccupancyRate(occuppancyRate);
    }
}
