namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IPushHotelServiceHandler {
    Task Execute(CancellationToken stoppingToken);
}
