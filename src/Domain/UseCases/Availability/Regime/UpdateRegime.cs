using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Regime;
public class UpdateRegime {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateRegime(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Restregi restregi) {
        if (restregi.Mrhab == "") {
            throw new ArgumentException("Incorrect regime code");
        }
        var regime = restregi.ToRegime();
        await availabilitySynchronizerApiClient.UpdateRegime(regime);
    }
}
