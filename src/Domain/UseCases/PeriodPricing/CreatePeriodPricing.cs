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
        if (DateTimeHelper.ConvertJulianDateToDateTime(conpreci.Cffec) == DateTime.MinValue) {
            throw new ArgumentException("Invalid price date");
        }
        if (string.IsNullOrWhiteSpace(conpreci.C4thab)) {
            throw new ArgumentException("Room code is required");
        }
        var periodPricing = conpreci.ToPeriodPricing();

        return availabilitySynchronizerApiClient.CreatePeriodPricing(periodPricing);
    }
}
