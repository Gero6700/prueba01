namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.CancellationPolicyLine;
public class CreateCancellationPolicy : ICreateCancellationPolicy {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateCancellationPolicy(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Congasan congasan) {
        
        var cancellationPolicyLine = congasan.ToCancellationPolicyLine();

        return await availabilitySynchronizerApiClient.CreateCancellationPolicy(cancellationPolicyLine);
    }
}
