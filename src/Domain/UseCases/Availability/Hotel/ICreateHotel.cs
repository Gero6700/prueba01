namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.Hotel;
public interface ICreateHotel {
    Task<HttpResponseMessage> Execute(Reshotel reshotel);
}
