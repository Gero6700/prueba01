namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelRoomConfiguration;

public class DeleteHotelRoomConfiguration :IDeleteHotelRoomConfiguration {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteHotelRoomConfiguration(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task<HttpResponseMessage> Execute(Resthaho resthaho) {
        throw new NotImplementedException();
    }
}
