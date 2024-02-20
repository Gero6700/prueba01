namespace Senator.As400.Cloud.Sync.Application.UseCases.MinimunStay;
public class UpdateMinimumStay {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateMinimumStay(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conestmi conestmi) {
        if (DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid start date");
        }
        if (DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid end date");
        }

        var minimumStay = conestmi.toMinimumStay();
        await availabilitySynchronizerApiClient.UpdateMinimumStay(minimumStay);
    }
}
