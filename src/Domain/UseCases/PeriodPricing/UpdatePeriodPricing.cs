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
        if (string.IsNullOrWhiteSpace(conpreci.C4thab)) {
            throw new ArgumentException("Room code is required");
        }
        if (string.IsNullOrWhiteSpace(conpreci.C4tser)) {
            throw new ArgumentException("Regime code is required");
        }
        if (string.IsNullOrWhiteSpace(conpreci.ContractClientCode)) {
            throw new ArgumentException("Contract client code is required");
        }
        if (string.IsNullOrWhiteSpace(conpreci.RateCode)) {
            throw new ArgumentException("Rate code is required");
        }
        var periodPricing = conpreci.ToPeriodPricing();

        await availabilitySynchronizerApiClient.UpdatePeriodPricing(periodPricing);
    }
}
