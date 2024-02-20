namespace Senator.As400.Cloud.Sync.Application.UseCases.Regime;
public class CreateRegime {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateRegime(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Restregi restregi) {
        var regime = restregi.ToRegime();

        await availabilitySynchronizerApiClient.CreateRegime(regime);
    }
}
