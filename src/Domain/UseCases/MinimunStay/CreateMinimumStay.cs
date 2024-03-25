namespace Senator.As400.Cloud.Sync.Application.UseCases.MinimunStay;
public class CreateMinimumStay {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMinimumStay(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conestmi conestmi) {
        if( DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid start date");
        }
        if( DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid end date");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec1) > DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec2)) {
            throw new ArgumentException("End date is less than start date");
        }
        if (String.IsNullOrWhiteSpace(conestmi.Code)) {
            throw new ArgumentException("Code is required");
        }
       
        var minimumStay = conestmi.toMinimumStay();
        await availabilitySynchronizerApiClient.CreateMinimumStay(minimumStay);
    }
}
