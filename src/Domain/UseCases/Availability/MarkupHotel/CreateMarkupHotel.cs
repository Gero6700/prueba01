using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.MarkupHotel;
public class CreateMarkupHotel {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMarkupHotel(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Mkuphote mkuphote) {
        var markupHotel = mkuphote.ToMarkupHotel();
        return await availabilitySynchronizerApiClient.CreateMarkupHotel(markupHotel);
    }
}
