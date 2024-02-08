namespace Senator.As400.Cloud.Sync.Application.UseCases.Extra;
public class CreateExtra {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateExtra(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }


    public async Task Execute(Conextra conextra) {
        var extra= conextra.ToExtra();   
        await availabilitySynchronizerApiClient.CreateExtra(extra);
    }
    
}
