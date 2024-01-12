namespace Senator.As400.Cloud.Sync.Application.UseCases;

public class CreateContract {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateContract(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task<Task> Execute(Concabec concabec) {
        Contract contract;
        ContractClient contractClient;

        try {
            contract = concabec.ToContract();
            contractClient = concabec.ToContractClient();
        }
        catch {
            throw new ContractMappingFailedException();
        }
        
        var response = await availabilitySynchronizerApiClient.CreateContract(contract);
        if (!response.Success) {
            throw new ContractCreationFailedException();
        }
        else {
            response = await availabilitySynchronizerApiClient.CreateContractClient(contractClient);
            if (!response.Success) {
                throw new ContractCreationFailedException();
            }
           
            return Task.CompletedTask;
        }

    }
}