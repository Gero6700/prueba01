namespace Senator.As400.Cloud.Sync.Application.UseCases;

public class CreateContract {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateContract(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Concabec concabec) {
        var contract = concabec.ToContract();
        var contractClient = concabec.ToContractClient();
        await availabilitySynchronizerApiClient.CreateContract(contract);
        await availabilitySynchronizerApiClient.CreateContractClient(contractClient);
    }
}