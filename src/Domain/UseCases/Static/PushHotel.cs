namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class PushHotel {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    private readonly IHotelService hotelService;

    public PushHotel(IStaticSynchronizerApiClient staticSynchronizerApiClient, IHotelService hotelService) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
        this.hotelService = hotelService;
    }
    public async Task<Result> Execute(int hotelId) {
        var hotel = await hotelService.GetHotelAsync(hotelId);
        if (hotel.IsFailure) {
            return Result.Failure(hotel.Error);
        }

        if (hotel.Value == null) {
            return Result.Failure(new Error("HotelService.HotelNotFound"));
        }

        try {
            var response = await staticSynchronizerApiClient.PushHotel(hotel.Value);
            if (response.IsSuccessStatusCode) {
                return Result.Success();
            }
            var content = await response.Content.ReadAsStringAsync();
            return Result.Failure(new Error("StaticSynchronizerApiClient.PushHotelError", content));

        } catch (Exception ex) {
            return Result.Failure(new Error("StaticSynchronizerApiClient.PushHotelError", ex.Message));
        }       
        
    }
}
