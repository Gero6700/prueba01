namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Hotel;
public interface IUpdateHotel {
    Task<HttpResponseMessage> Execute(Reshotel reshotel);
}
