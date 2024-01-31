namespace Senator.As400.Cloud.Sync.Application.UseCases.HotelRoomConfiguration;

public class DeleteHotelRoomConfiguration { 
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteHotelRoomConfiguration(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task Execute(Resthaho resthaho) {
        var hotelRoomConfiguration = resthaho.ToHotelRoomConfiguration();
        return availabilitySynchronizerApiClient.DeleteHotelRoomConfiguration(hotelRoomConfiguration);
    }
}
