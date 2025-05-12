namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IPushServiceCategoryHandler {
    Task Execute(CancellationToken stoppingToken);
}
