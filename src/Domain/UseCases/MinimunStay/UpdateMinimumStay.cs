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
        if (DateTimeHelper.ConvertJulianDateToDateTime(conestmi.Cofec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid contract start date");
        }
        if (DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec1) < DateTimeHelper.ConvertJulianDateToDateTime(conestmi.Cofec1)) {
            throw new ArgumentException("Start date is less than contract start date");
        }
        if (conestmi.C7fec1 > conestmi.C7fec2) {
            throw new ArgumentException("End date is less than start date");
        }
        if (conestmi.C7hote == 0) {
            throw new ArgumentException("Incorrect hotel code");
        }

        var minimumStay = conestmi.toMinimumStay();
        await availabilitySynchronizerApiClient.UpdateMinimumStay(minimumStay);
    }
}
