namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OccupancyRate;
public class DeleteOccupancyRate {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteOccupancyRate(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(string cocod) {
        if (string.IsNullOrWhiteSpace(cocod)) {
            throw new ArgumentException("Code is required");
        }
        await availabilitySynchronizerApiClient.DeleteOccupancyRate(cocod);
    }
}
