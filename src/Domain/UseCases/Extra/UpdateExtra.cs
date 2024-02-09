namespace Senator.As400.Cloud.Sync.Application.UseCases.Extra;

public class UpdateExtra {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateExtra(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
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
        var extra = conextra.ToExtra();
        await availabilitySynchronizerApiClient.UpdateExtra(extra);
    }
}
