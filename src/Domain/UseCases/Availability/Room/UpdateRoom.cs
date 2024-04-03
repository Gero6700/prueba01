using Senator.As400.Cloud.Sync.Infrastructure.Extensions.Availability;

namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Room;
public class UpdateRoom {
    private readonly IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient;

    public UpdateRoom(IAvailabilitySynchronizerApiClient availabilitySynchronizerApiClient) {
        this.availabilitySynchronizerApiClient = availabilitySynchronizerApiClient;
    }

    public async Task Execute(Resthabi resthabi) {
        if (resthabi.Mthab == "") {
            throw new ArgumentException("Incorrect room code");
        }
        var room = resthabi.ToRoom();
        await availabilitySynchronizerApiClient.UpdateRoom(room);
    }

}
