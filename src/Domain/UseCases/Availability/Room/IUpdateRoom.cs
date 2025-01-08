namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Room;
public interface IUpdateRoom {
    Task<HttpResponseMessage> Execute(Resthabi resthabi);
}
