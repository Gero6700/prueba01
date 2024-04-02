namespace Senator.As400.Cloud.Sync.Application.UseCases.OccupancyRate;
public class DeleteOccupancyRate {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    
    public DeleteOccupancyRate(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(string cocod) {
        await availabilitySynchronizerApiClient.DeleteOccupancyRate(cocod);
    }
}
