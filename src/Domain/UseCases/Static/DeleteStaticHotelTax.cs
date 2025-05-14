namespace Senator.As400.Cloud.Sync.Application.UseCases.Static;
public class DeleteStaticHotelTax {
    private readonly IStaticSynchronizerApiClient staticSynchronizerApiClient;
    public DeleteStaticHotelTax(IStaticSynchronizerApiClient staticSynchronizerApiClient) {
        this.staticSynchronizerApiClient = staticSynchronizerApiClient;
    }

    public Task<HttpResponseMessage> Execute(Reszoimh reszoimH) {
        var hotelTax = reszoimH.ToHotelTax();
        return staticSynchronizerApiClient.DeleteHotelTax(hotelTax);
    }
}
