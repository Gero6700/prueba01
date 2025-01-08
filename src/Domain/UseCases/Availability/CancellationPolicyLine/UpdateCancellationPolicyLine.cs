namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.CancellationPolicyLine;
public class UpdateCancellationPolicyLine : IUpdateCancellationPolicyLine {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateCancellationPolicyLine(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Congasan congasan) {
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(congasan.C6fec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid from date");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(congasan.C6fec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid to date");
        }
        if (congasan.C6fec2 < congasan.C6fec1) {
            throw new ArgumentException("From date is less than to date");
        }
        var cancellationPolicyLine = congasan.ToCancellationPolicyLine();

        return await availabilitySynchronizerApiClient.UpdateCancellationPolicyLine(cancellationPolicyLine);
    }
}
