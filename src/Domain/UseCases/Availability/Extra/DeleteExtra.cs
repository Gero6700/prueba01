namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Extra;
public class DeleteExtra :IDeleteExtra {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    public DeleteExtra(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task<HttpResponseMessage> Execute(Conextra conextra) {
        var extra = conextra.ToExtra();
        return availabilitySynchronizerApiClient.DeleteExtra(extra.Code);
    }
}
