using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Extra;

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
        if (DateTimeHelper.ConvertJulianDateToDateTime(conextra.C5fec2) == DateTime.MinValue) {
            throw new ArgumentException("Invalid check-in to date");
        }
        if (conextra.C5fred > conextra.C5freh) {
            throw new ArgumentException("Apply to date is less than apply from date");
        }
        if (conextra.C5fec1 > conextra.C5fec2) {
            throw new ArgumentException("Check-in to date is less than check-in from date");
        }
        if (conextra.C5died > conextra.C5dieh) {
            throw new ArgumentException("Stay to date is less than stay from date");
        }
        if (conextra.OriginCode == "") {
            throw new ArgumentException("Origin code is required");
        }
        var extra = conextra.ToExtra();
        await availabilitySynchronizerApiClient.UpdateExtra(extra);
    }
}
