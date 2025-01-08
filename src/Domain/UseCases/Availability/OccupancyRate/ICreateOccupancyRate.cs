namespace Senator.As400.Cloud.Sync.Application.UseCases.Availability.OccupancyRate;
public interface ICreateOccupancyRate {
    Task<HttpResponseMessage> Execute(Resthaco resthaco);
}

