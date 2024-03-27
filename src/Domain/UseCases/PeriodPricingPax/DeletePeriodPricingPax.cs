namespace Senator.As400.Cloud.Sync.Application.UseCases.PeriodPricingPax;
public class DeletePeriodPricingPax{
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeletePeriodPricingPax(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(string Code) {
        await availabilitySynchronizerApiClient.DeletePeriodPricingPax(Code);
    }
}
