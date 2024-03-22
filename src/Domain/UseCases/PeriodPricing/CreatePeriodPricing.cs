namespace Senator.As400.Cloud.Sync.Application.UseCases.PeriodPricing;
public class CreatePeriodPricing {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreatePeriodPricing(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task Execute(Conpreci conpreci) {
        if (conpreci.Cffec == 0) {
            throw new ArgumentException("Price date is required");
        }
        var periodPricing = conpreci.ToPeriodPricing();

        return availabilitySynchronizerApiClient.CreatePeriodPricing(periodPricing);
    }
}
