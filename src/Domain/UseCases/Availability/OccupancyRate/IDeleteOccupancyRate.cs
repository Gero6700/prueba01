namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OccupancyRate;
public interface IDeleteOccupancyRate {
    Task<HttpResponseMessage> Execute(string cocod);
}
