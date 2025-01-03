namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Room;
public class DeleteRoom : IDeleteRoom {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteRoom(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthabi resthabi) {
        var room = resthabi.ToRoom();
        await availabilitySynchronizerApiClient.DeleteRoom(room.Code);
    }
}
