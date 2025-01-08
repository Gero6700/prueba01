namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelRoomConfiguration;
public interface ICreateHotelRoomConfiguration {
        Task<HttpResponseMessage> Execute(Resthaho resthaho);
}
