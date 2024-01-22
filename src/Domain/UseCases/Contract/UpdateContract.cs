namespace Senator.As400.Cloud.Sync.Application.UseCases.Contract;

public class UpdateContract {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateContract(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Concabec concabec) {
        var contract = concabec.ToContract();
        var contractClient = concabec.ToContractClient();
        await availabilitySynchronizerApiClient.UpdateContract(contract);
        await availabilitySynchronizerApiClient.UpdateContractClient(contractClient);
    }
}