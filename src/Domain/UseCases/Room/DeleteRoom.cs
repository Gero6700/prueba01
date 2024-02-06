namespace Senator.As400.Cloud.Sync.Application.UseCases.Room;
public class DeleteRoom{
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public DeleteRoom(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }
   
    public async  Task Execute(Resthabi resthabi) {
        var room = resthabi.ToRoom();
        await availabilitySynchronizerApiClient.DeleteRoom(room.Code);
    }
}
