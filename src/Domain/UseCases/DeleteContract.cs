namespace Senator.As400.Cloud.Sync.Application.UseCases;

public class DeleteContract {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteContract(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
  
    public async Task Execute(Concabec concabec) {
        var code = concabec.Code;

        await availabilitySynchronizerApiClient.DeleteContract(code);    
    }
}