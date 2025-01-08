namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Room;
public class UpdateRoom : IUpdateRoom {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateRoom(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task<HttpResponseMessage> Execute(Resthabi resthabi) {
        if (resthabi.Mthab == "") {
            throw new ArgumentException("Incorrect room code");
        }
        var room = resthabi.ToRoom();
        return await availabilitySynchronizerApiClient.UpdateRoom(room);
    }
}
