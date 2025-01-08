namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OccupancyRate;
public interface IUpdateOccupancyRate {
    Task<HttpResponseMessage> Execute(Resthaco resthaco);
}
