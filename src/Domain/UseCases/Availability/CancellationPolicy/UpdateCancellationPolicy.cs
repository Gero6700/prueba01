namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.CancellationPolicyLine;
public class UpdateCancellationPolicy : IUpdateCancellationPolicy {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateCancellationPolicy(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Congasan congasan) {
        
        var cancellationPolicyLine = congasan.ToCancellationPolicyLine();

        return await availabilitySynchronizerApiClient.UpdateCancellationPolicy(cancellationPolicyLine);
    }
}
