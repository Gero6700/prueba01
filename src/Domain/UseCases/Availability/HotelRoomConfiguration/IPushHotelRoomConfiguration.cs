namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelRoomConfiguration;
public interface IPushHotelRoomConfiguration {
        Task<HttpResponseMessage> Execute(Resthaho resthaho);
}
