namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Regime;
public class CreateMeal : ICreateMeal {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMeal(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Restregi restregi) {
        if (restregi.Mrhab == "") {
            throw new ArgumentException("Incorrect regime code");
        }

        var regime = restregi.ToRegime();
        return await availabilitySynchronizerApiClient.CreateMeal(regime);
    }
}
