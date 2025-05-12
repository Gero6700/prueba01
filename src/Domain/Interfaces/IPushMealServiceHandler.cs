namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IPushMealServiceHandler {
    Task Execute(CancellationToken stoppingToken);
}
