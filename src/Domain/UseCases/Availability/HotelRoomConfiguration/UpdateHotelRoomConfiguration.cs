namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelRoomConfiguration;
public class UpdateHotelRoomConfiguration :IUpdateHotelRoomConfiguration {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateHotelRoomConfiguration(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthaho resthaho) {
        if (resthaho.Tihote == 0) {
            throw new ArgumentException("Incorrect hotel code");
        }
        if (resthaho.Tihab == "") {
            throw new ArgumentException("Incorrect room code");
        }
        if (resthaho.Tihabg == "") {
            throw new ArgumentException("Incorrect inventory room type code");
        }
        if (resthaho.Ticonf == 0) {
            throw new ArgumentException("Incorrect occupancy rate code");
        }

        var hotelRoomConfiguration = resthaho.ToHotelRoomConfiguration();
        await availabilitySynchronizerApiClient.UpdateHotelRoomConfiguration(hotelRoomConfiguration);
    }
}
