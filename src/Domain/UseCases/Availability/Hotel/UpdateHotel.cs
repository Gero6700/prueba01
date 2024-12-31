
namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Hotel;
public class UpdateHotel : IUpdateHotel {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateHotel(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task Execute(Reshotel reshotel) {
        if (string.IsNullOrWhiteSpace(reshotel.Hotcod)) {
            throw new ArgumentException("Invalid hotel code");
        }
        var hotel = reshotel.ToHotel();
        return availabilitySynchronizerApiClient.UpdateHotel(hotel);
    }
}
