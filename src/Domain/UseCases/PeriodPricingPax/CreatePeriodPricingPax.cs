using System.Runtime.CompilerServices;

namespace Senator.As400.Cloud.Sync.Application.UseCases.PeriodPricingPax;
public class CreatePeriodPricingPax {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreatePeriodPricingPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Condtos condtos) {
        if (string.IsNullOrEmpty(condtos.Code)) {
            throw new ArgumentException("Code is required");
        }
        if (string.IsNullOrEmpty(condtos.PeriodPricingCode)) {
            throw new ArgumentException("Period pricing code is required");
        }
        if (string.IsNullOrEmpty(condtos.D4tipa)) {
            throw new ArgumentException("Pax type is required");
        }
        var periodPricingPax = condtos.ToPeriodPricingPax();
        await availabilitySynchronizerApiClient.CreatePeriodPricingPax(periodPricingPax);
    }
}
