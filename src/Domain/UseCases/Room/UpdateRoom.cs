namespace Senator.As400.Cloud.Sync.Application.UseCases.Room;
public class UpdateRoom {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateRoom(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthabi resthabi) {
        var room = resthabi.ToRoom();
        await availabilitySynchronizerApiClient.UpdateRoom(room);
    }
    
}
