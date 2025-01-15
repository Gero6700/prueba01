namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Hotel;

public class CreateHotel : ICreateHotel {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateHotel(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Reshotel reshotel) {
        if (string.IsNullOrWhiteSpace(reshotel.Hotcod)) {
            throw new ArgumentException("Invalid hotel code");
        }
        var hotel = reshotel.ToHotel();
        return await availabilitySynchronizerApiClient.CreateHotel(hotel);
    }
}

