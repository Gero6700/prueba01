using System.Runtime.CompilerServices;
using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricingPax;
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
        if (condtos.D4tipa.Length < 6) {
            throw new ArgumentException("Pax type length is less than 6");
        }
        if (int.TryParse(condtos.D4tipa.Trim()[5..], out _) == false) {
            throw new ArgumentException("Pax order is not a number");
        }
        if (condtos.D4desd < 0) {
            throw new ArgumentException("Age from is negative");
        }
        if (condtos.D4has < 0) {
            throw new ArgumentException("Age to is negative");
        }
        if (condtos.D4has < condtos.D4desd) {
            throw new ArgumentException("Age to is less than age from");
        }
        var periodPricingPax = condtos.ToPeriodPricingPax();
        await availabilitySynchronizerApiClient.CreatePeriodPricingPax(periodPricingPax);
    }
}
