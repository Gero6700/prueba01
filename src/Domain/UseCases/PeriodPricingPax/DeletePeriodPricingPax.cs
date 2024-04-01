namespace Senator.As400.Cloud.Sync.Application.UseCases.PeriodPricingPax;
public class DeletePeriodPricingPax{
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeletePeriodPricingPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(string Code) {
        if (string.IsNullOrEmpty(Code)) {
            throw new ArgumentException("Code is required");
        }
        await availabilitySynchronizerApiClient.DeletePeriodPricingPax(Code);
    }
}
