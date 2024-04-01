namespace Senator.As400.Cloud.Sync.Application.UseCases.OcuppanceRate;
public class CreateOcuppancyRate {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    
    public CreateOcuppancyRate(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthaco resthaco) {
        var occuppancyRate = resthaco.ToOcuppancyRate();
        await availabilitySynchronizerApiClient.CreateOcuppancyRate(occuppancyRate);
    }
}
