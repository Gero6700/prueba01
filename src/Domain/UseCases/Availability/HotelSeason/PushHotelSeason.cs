namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelSeason;

public class PushHotelSeason : IPushHotelSeason {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public PushHotelSeason(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Hotape hotape) {
        if (hotape.Aphote == 0) {
            throw new ArgumentException("Incorrect hotel code");
        }
        
        var hotelSeasons = hotape.ToHotelSeasons();
        return await availabilitySynchronizerApiClient.PushHotelSeasons(hotelSeasons);

    }
}
