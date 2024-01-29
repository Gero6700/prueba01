namespace Senator.As400.Cloud.Sync.Application.UseCases.HotelRoomConfiguration;
public class CreateHotelRoomConfiguration {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateHotelRoomConfiguration(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthaho resthaho) {
        if (resthaho.Tihote == 0) {
            throw new ArgumentException("Incorrect hotel code");
        }
        var hotelRoomConfiguration = resthaho.ToHotelRoomConfiguration();
        await availabilitySynchronizerApiClient.CreateHotelRoomConfiguration(hotelRoomConfiguration);
    }
}
