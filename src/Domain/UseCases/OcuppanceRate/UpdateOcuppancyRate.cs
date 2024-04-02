namespace Senator.As400.Cloud.Sync.Application.UseCases.OcuppanceRate;
public class UpdateOcuppancyRate {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOcuppancyRate(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthaco resthaco) {
        if (string.IsNullOrWhiteSpace(resthaco.Cocod)) {
            throw new ArgumentException("Code is required");
        }
        var occuppancyRate = resthaco.ToOcuppancyRate();
        await availabilitySynchronizerApiClient.UpdateOcuppancyRate(occuppancyRate);
    }
}
