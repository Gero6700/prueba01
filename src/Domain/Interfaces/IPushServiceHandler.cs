namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IPushServiceHandler {
    Task Execute(CancellationToken stoppingToken);
}
