namespace Senator.As400.Cloud.Sync.Application.UseCases.PeriodPricing;
public class UpdatePeriodPricing {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;
    
    public UpdatePeriodPricing(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Conpreci conpreci) {
        if (conpreci.Cffec == 0) {
            throw new ArgumentException("Price date is required");
        }
        if (DateTimeHelper.ConvertJulianDateToDateTime(conpreci.Cffec) == DateTime.MinValue) {
            throw new ArgumentException("Invalid price date");
        }
        var periodPricing = conpreci.ToPeriodPricing();

        await availabilitySynchronizerApiClient.UpdatePeriodPricing(periodPricing);
    }
}
