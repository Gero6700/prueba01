namespace Senator.As400.Cloud.Sync.Application.UseCases.Markup;

public class UpdateMarkup {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateMarkup(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Mkupcabe mkupcabe) {
        var markup = mkupcabe.ToMarkup();  
        await availabilitySynchronizerApiClient.UpdateMarkup(markup);
    }
    
}
