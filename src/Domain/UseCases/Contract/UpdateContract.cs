namespace Senator.As400.Cloud.Sync.Application.UseCases.Contract;

public class UpdateContract {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateContract(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Concabec concabec) {
        if (DateTimeHelper.ConvertJulianDateToDateTime(concabec.Cofec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid start date");
        }
        if (DateTimeHelper.ConvertJulianDateToDateTime(concabec.Cofec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid end date");
        }
        if (concabec.Cofext > 0 && DateTimeHelper.ConvertIntegerToDatetime(concabec.Cofext) == null) {
            throw new ArgumentException("Invalid extinction date");
        }

        var contract = concabec.ToContract();
        var contractClient = concabec.ToContractClient();
        await availabilitySynchronizerApiClient.UpdateContract(contract);
        await availabilitySynchronizerApiClient.UpdateContractClient(contractClient);
    }
}