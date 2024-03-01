namespace Senator.As400.Cloud.Sync.Application.UseCases.CancellationPolicyLine;
public class CreateCancellationPolicyLine {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateCancellationPolicyLine(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Congasan congasan) {
        if (DateTimeHelper.ConvertIntegerToDatetime(congasan.C6fec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid from date");
        }
        var cancellationPolicyLine=congasan.ToCancellationPolicyLine();

        await availabilitySynchronizerApiClient.CreateCancellationPolicyLine(cancellationPolicyLine);
    }
}
