namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelSeason;
public interface IPushHotelSeason {
    Task<HttpResponseMessage> Execute(Hotape hotape);
}