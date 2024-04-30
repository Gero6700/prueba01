namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushStaticHotel {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;

    public PushStaticHotel(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public async Task Execute(EstHotel estHotel) {
        var hotel = estHotel.ToHotel();
        await staticSynchronizerApiClient.PushHotel(hotel);
    }
}
