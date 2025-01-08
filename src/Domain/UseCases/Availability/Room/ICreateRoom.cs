namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Room;
public interface ICreateRoom {
    Task<HttpResponseMessage> Execute(Resthabi resthabi);
}
