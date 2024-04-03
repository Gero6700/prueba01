using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.MinimunStay;
public class UpdateMinimumStay {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateMinimumStay(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conestmi conestmi) {
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid start date");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(conestmi.C7fec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid end date");
        }
        if (conestmi.C7fec1 > conestmi.C7fec2) {
            throw new ArgumentException("End date is less than start date");
        }
        if (string.IsNullOrWhiteSpace(conestmi.Code)) {
            throw new ArgumentException("Code is required");
        }
        if (string.IsNullOrWhiteSpace(conestmi.ContractClientCode)) {
            throw new ArgumentException("Contract client code is required");
        }

        var minimumStay = conestmi.toMinimumStay();
        await availabilitySynchronizerApiClient.UpdateMinimumStay(minimumStay);
    }
}
