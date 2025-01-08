namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelRoomConfiguration;
public interface IDeleteHotelRoomConfiguration {
    Task<HttpResponseMessage> Execute(Resthaho resthaho);
}
