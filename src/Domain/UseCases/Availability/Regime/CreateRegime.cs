namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Regime;
public class CreateRegime : ICreateRegimen {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateRegime(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Restregi restregi) {
        if (restregi.Mrhab == "") {
            throw new ArgumentException("Incorrect regime code");
        }

        var regime = restregi.ToRegime();
        return await availabilitySynchronizerApiClient.CreateRegime(regime);
    }
}
