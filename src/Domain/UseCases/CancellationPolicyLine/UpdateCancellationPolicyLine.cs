namespace Senator.As400.Cloud.Sync.Application.UseCases.CancellationPolicyLine;
public class UpdateCancellationPolicyLine {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateCancellationPolicyLine(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Congasan congasan) {
        var cancellationPolicyLine = congasan.ToCancellationPolicyLine();

        await availabilitySynchronizerApiClient.UpdateCancellationPolicyLine(cancellationPolicyLine);
    }
}
