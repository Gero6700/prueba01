namespace Senator.As400.Cloud.Sync.Application.UseCases.MarkupHotel;
public class CreateMarkupHotel {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMarkupHotel(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Mkuphote mkuphote) {
        var markupHotel = mkuphote.ToMarkupHotel();
        await availabilitySynchronizerApiClient.CreateMarkupHotel(markupHotel);
    }
}
