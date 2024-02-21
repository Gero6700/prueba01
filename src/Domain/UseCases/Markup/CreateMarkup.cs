namespace Senator.As400.Cloud.Sync.Application.UseCases.Markup;
public class CreateMarkup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateMarkup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Mkupcabe mkupcabe) {
        var markup = mkupcabe.ToMarkup();
        await availabilitySynchronizerApiClient.CreateMarkup(markup);
    }
}
