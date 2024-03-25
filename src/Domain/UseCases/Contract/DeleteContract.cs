namespace Senator.As400.Cloud.Sync.Application.UseCases.Contract;

public class DeleteContract {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteContract(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(String code) {
        if (string.IsNullOrWhiteSpace(code)) {
            throw new ArgumentException("Contract client code is required");
        }       
        await availabilitySynchronizerApiClient.DeleteContractClient(code);
    }
}