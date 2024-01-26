namespace Senator.As400.Cloud.Sync.Application.UseCases.Hotel;
public class UpdateHotel {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateHotel(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task Execute(Reshotel reshotel) {
        if (reshotel.Hotcod == 0) {
            throw new ArgumentException("Invalid hotel code");
        }
        var hotel= reshotel.ToHotel();
        return availabilitySynchronizerApiClient.UpdateHotel(hotel);
    }
}
