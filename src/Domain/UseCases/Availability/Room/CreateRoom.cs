using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Room;
public class CreateRoom {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public CreateRoom(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthabi resthabi) {
        if (resthabi.Mthab == "") {
            throw new ArgumentException("Incorrect room code");
        }
        var room = resthabi.ToRoom();
        await availabilitySynchronizerApiClient.CreateRoom(room);
    }
}
