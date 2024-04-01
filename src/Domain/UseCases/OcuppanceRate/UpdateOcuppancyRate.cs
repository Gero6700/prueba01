namespace Senator.As400.Cloud.Sync.Application.UseCases.OcuppanceRate;
public class UpdateOcuppancyRate {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateOcuppancyRate(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthaco resthaco) {
        var occuppancyRate = resthaco.ToOcuppancyRate();
        await availabilitySynchronizerApiClient.UpdateOcuppancyRate(occuppancyRate);
    }
}
