namespace Senator.As400.Cloud.Sync.Application.UseCases.Hotel;
public class UpdateHotel {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateHotel(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task Execute(Reshotel reshotel) {
        var hotel= reshotel.ToHotel();
        return availabilitySynchronizerApiClient.UpdateHotel(hotel);
    }
}
