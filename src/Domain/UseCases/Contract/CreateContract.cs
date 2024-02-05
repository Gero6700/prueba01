namespace Senator.As400.Cloud.Sync.Application.UseCases.Contract;

public class CreateContract {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateContract(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Concabec concabec) {
        if (DateTimeHelper.ConvertJulianDateToDateTime(concabec.Cofec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid start date");
        }
        if (DateTimeHelper.ConvertJulianDateToDateTime(concabec.Cofec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid end date");
        }
        if (concabec.Cofext>0 && DateTimeHelper.ConvertIntegerToNullableDatetime(concabec.Cofext) == null) {
            throw new ArgumentException("Invalid extinction date");
        }
        if (concabec.Cofec1 > concabec.Cofec2) {
            throw new ArgumentException("End date is less than start date");
        }
        if (concabec.Idusuario == 0) {
            throw new ArgumentException("Incorrect user code");
        }
        if (concabec.Cohote == 0) {
            throw new ArgumentException("Incorrect hotel code");
        }
        if (concabec.Codmerca =="") {
            throw new ArgumentException("Incorrect market code");
        }
        if (concabec.Dinom2.Length != 3 || !concabec.Dinom2.All(char.IsLetter)) {
            throw new ArgumentException("Invalid currency iso code");
        }

        var contract = concabec.ToContract();
        var contractClient = concabec.ToContractClient();
        await availabilitySynchronizerApiClient.CreateContract(contract);
        await availabilitySynchronizerApiClient.CreateContractClient(contractClient);
    }
}