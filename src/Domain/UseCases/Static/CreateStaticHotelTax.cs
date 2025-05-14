
namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class CreateStaticHotelTax {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public CreateStaticHotelTax(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }
    public Task<HttpResponseMessage> Execute(Reszoimh reszoimH) {
        var hotelTax = reszoimH.ToHotelTax();
        return staticSynchronizerApiClient.CreateHotelTax(hotelTax);
    }
}
