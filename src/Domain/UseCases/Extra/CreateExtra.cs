using Senator.As400.Cloud.Sync.Infrastructure.Dtos.As400;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Extra;
public class CreateExtra {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateExtra(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }


    public async Task Execute(Conextra conextra) {
        if (DateTimeHelper.ConvertJulianDateToDateTime(conextra.C5fred) == DateTime.MinValue) {
            throw new ArgumentException("Invalid apply from date");
        }
        if (DateTimeHelper.ConvertJulianDateToDateTime(conextra.C5freh) == DateTime.MinValue) {
            throw new ArgumentException("Invalid apply to date");
        }
        if (DateTimeHelper.ConvertJulianDateToDateTime(conextra.C5fec1) == DateTime.MinValue) {
            throw new ArgumentException("Invalid check-in from date");
        }
        if (DateTimeHelper.ConvertJulianDateToDateTime(conextra.C5fec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid check-in to date");
        }
        if (conextra.C5fred > conextra.C5freh) {
            throw new ArgumentException("Apply to date is less than apply from date");
        }
        var extra= conextra.ToExtra();   
        await availabilitySynchronizerApiClient.CreateExtra(extra);
    }
    
}
