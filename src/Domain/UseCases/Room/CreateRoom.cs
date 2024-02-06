namespace Senator.As400.Cloud.Sync.Application.UseCases.Room;
public class CreateRoom {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateRoom(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthabi resthabi) {
        var room = resthabi.ToRoom();
        await availabilitySynchronizerApiClient.CreateRoom(room);
    }
}
