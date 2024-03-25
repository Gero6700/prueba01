namespace Senator.As400.Cloud.Sync.Application.UseCases.PeriodPricing;
public class UpdatePeriodPricing {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    
    public UpdatePeriodPricing(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conpreci conpreci) {
        var periodPricing = conpreci.ToPeriodPricing();

        await availabilitySynchronizerApiClient.UpdatePeriodPricing(periodPricing);
    }
}
