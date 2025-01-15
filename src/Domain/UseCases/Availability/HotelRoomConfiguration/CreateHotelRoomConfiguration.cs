namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelRoomConfiguration;
public class CreateHotelRoomConfiguration :ICreateHotelRoomConfiguration {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateHotelRoomConfiguration(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Resthaho resthaho) {
        if (resthaho.Tihote == 0) {
            throw new ArgumentException("Incorrect hotel code");
        }
        if (resthaho.Tihab == "") {
            throw new ArgumentException("Incorrect room code");
        }
        if (resthaho.Tihabg == "") {
            throw new ArgumentException("Incorrect inventory room code");
        }
        //TODO: Pendiente de si puede venir una habitacion sin configuracion de ocupacion
        if (resthaho.Ticonf == 0) {
            throw new ArgumentException("Incorrect occupancy rate code");
        }
        var hotelRoomConfiguration = resthaho.ToHotelRoomConfiguration();
        return await availabilitySynchronizerApiClient.CreateHotelRoomConfiguration(hotelRoomConfiguration);
    }
}
