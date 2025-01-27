namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.MinimunStay;
public class DeleteMinimumStay : IDeleteMinimumStay {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    public DeleteMinimumStay(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
    public async Task<HttpResponseMessage> Execute(string Code) {
        if (string.IsNullOrEmpty(Code)) {
            throw new ArgumentException("Code is required");
        }
        return await availabilitySynchronizerApiClient.DeleteMinimunStay(Code);
    }
}
