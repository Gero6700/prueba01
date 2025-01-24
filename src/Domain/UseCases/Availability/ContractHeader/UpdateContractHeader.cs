namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Contract;

public class UpdateContractHeader : IUpdateContractHeader {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateContractHeader(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Concabec concabec) {
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(concabec.Cofec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid start date");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(concabec.Cofec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid end date");
        }
        if (concabec.Cofext > 0 && DateTimeHelper.ConvertYYYYMMDDToNullableDatetime(concabec.Cofext) == null) {
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
        if (concabec.Codmerca == "") {
            throw new ArgumentException("Incorrect market code");
        }
        if (concabec.Dinom2.Length != 3 || !concabec.Dinom2.All(char.IsLetter)) {
            throw new ArgumentException("Invalid currency iso code");
        }
        if (string.IsNullOrWhiteSpace(concabec.ContractCode)) {
            throw new ArgumentException("Contract code is required");
        }
        if (string.IsNullOrWhiteSpace(concabec.ContractClientCode)) {
            throw new ArgumentException("Contract client code is required");
        }

        var contract = concabec.ToContract();
        var contractClient = concabec.ToContractClient();
        var responseContract = await availabilitySynchronizerApiClient.UpdateContractHeader(contract);
        var responseContractClient = await availabilitySynchronizerApiClient.UpdateIntegrationContract(contractClient);

        return responseContract.IsSuccessStatusCode
            ? responseContractClient
            : responseContract;
    }
}