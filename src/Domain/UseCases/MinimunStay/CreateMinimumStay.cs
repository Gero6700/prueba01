namespace Senator.As400.Cloud.Sync.Application.UseCases.MinimunStay;
public class CreateMinimumStay {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMinimumStay(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conestmi conestmi) {
        if( DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid start date");
        }
        if( DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid end date");
        }
        if(DateTimeHelper.ConvertJulianDateToDateTime(conestmi.Cofec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid contract start date");
        }
        if(DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec1) < DateTimeHelper.ConvertJulianDateToDateTime(conestmi.Cofec1)) {
            throw new ArgumentException("Start date is less than contract start date");
        }
        if (DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec1) > DateTimeHelper.ConvertIntegerToDatetime(conestmi.C7fec2)) {
            throw new ArgumentException("End date is less than start date");
        }

        var minimumStay = conestmi.toMinimumStay();
        await availabilitySynchronizerApiClient.CreateMinimumStay(minimumStay);
    }
}
