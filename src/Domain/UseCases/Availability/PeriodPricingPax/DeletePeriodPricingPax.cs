namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricingPax;
public class DeletePeriodPricingPax : IDeletePeriodPricingPax {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeletePeriodPricingPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(string Code) {
        if (string.IsNullOrEmpty(Code)) {
            throw new ArgumentException("Code is required");
        }
        return await availabilitySynchronizerApiClient.DeletePeriodPricingPax(Code);
    }
}
