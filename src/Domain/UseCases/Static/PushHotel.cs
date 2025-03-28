namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushHotel {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private readonly IHotelService hotelService;

    public PushHotel(IStaticSynchronizerApiClient staticSynchronizerApiClient, IHotelService hotelService) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
        this.hotelService = hotelService;
    }
    public async Task<HttpResponseMessage> Execute(int hotelId) {
        if (hotelId <= 0) {
            throw new ArgumentException("Invalid hotel id");
        }
        var hotel = await hotelService.GetHotelAsync(hotelId);
        return await staticSynchronizerApiClient.PushHotel(hotel);
    }
}
