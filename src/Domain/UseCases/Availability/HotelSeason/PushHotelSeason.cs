namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelSeason;

public class PushHotelSeason : IPushHotelSeason {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public PushHotelSeason(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Hotape hotape) {
        
        var hotelSeasons = hotape.ToHotelSeasons();
        return await availabilitySynchronizerApiClient.PushHotelSeasons(hotelSeasons);

    }
}
