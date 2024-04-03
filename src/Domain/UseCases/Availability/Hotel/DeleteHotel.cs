using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Hotel;
public class DeleteHotel {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteHotel(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task Execute(Reshotel reshotel) {
        var hotel = reshotel.ToHotel();
        return availabilitySynchronizerApiClient.DeleteHotel(hotel.Code);
    }
}
