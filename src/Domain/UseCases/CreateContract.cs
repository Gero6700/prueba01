using System.Globalization;


namespace Senator.As400.Cloud.Sync.Application.UseCases;

public class CreateContract {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateContract(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Concabec concabec) {
        if (DateTimeHelper.ConvertJulianDateToDateTime(concabec.Cofec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid start date");
        }

        var contract = concabec.ToContract();
        var contractClient = concabec.ToContractClient();
        await availabilitySynchronizerApiClient.CreateContract(contract);
        await availabilitySynchronizerApiClient.CreateContractClient(contractClient);
    }
}