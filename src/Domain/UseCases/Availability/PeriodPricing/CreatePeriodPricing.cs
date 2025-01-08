namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricing;
public class CreatePeriodPricing : ICreatePeriodPricing {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreatePeriodPricing(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public Task<HttpResponseMessage> Execute(Conpreci conpreci) {
        if (conpreci.Cffec == 0) {
            throw new ArgumentException("Price date is required");
        }
        if (DateTimeHelper.ConvertYYYYMMDDToDatetime(conpreci.Cffec) == DateTime.MinValue) {
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
        if (conpreci.C4esta <= 0) {
            throw new ArgumentException("Stay price must be greater than zero");
        }
        var periodPricing = conpreci.ToPeriodPricing();

        return availabilitySynchronizerApiClient.CreatePeriodPricing(periodPricing);
    }
}
