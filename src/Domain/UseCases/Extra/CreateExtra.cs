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
        var extra= conextra.ToExtra();   
        await availabilitySynchronizerApiClient.CreateExtra(extra);
    }
    
}
