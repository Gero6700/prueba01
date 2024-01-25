namespace Senator.As400.Cloud.Sync.Application.UseCases.Hotel;

public class CreateHotel {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateHotel(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Reshotel reshotel) {
        var hotel= reshotel.ToHotel();
        await availabilitySynchronizerApiClient.CreateHotel(hotel);
    }
}

