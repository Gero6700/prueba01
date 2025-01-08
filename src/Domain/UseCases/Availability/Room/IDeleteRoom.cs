namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Room;
public interface IDeleteRoom {
    Task<HttpResponseMessage> Execute(Resthabi resthabi);
}
