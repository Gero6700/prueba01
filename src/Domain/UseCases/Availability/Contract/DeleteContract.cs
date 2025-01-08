namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Contract;

public class DeleteContract : IDeleteContract {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteContract(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(string code) {
        if (string.IsNullOrWhiteSpace(code)) {
            throw new ArgumentException("Contract client code is required");
        }
        return await availabilitySynchronizerApiClient.DeleteContractClient(code);
    }
}