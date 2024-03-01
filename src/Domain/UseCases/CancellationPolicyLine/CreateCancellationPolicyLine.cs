namespace Senator.As400.Cloud.Sync.Application.UseCases.CancellationPolicyLine;
public class CreateCancellationPolicyLine {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateCancellationPolicyLine(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Congasan congasan) {
        var cancellationPolicyLine=congasan.ToCancellationPolicyLine();

        await availabilitySynchronizerApiClient.CreateCancellationPolicyLine(cancellationPolicyLine);
    }
}
