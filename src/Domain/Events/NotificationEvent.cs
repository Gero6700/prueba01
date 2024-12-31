namespace Senator.As400.Cloud.Sync.Application.Events;
public abstract class NotificationEvent {
    public string Operation { get; set; } = string.Empty;
    public string Table { get; set; } = string.Empty;
    public string Data { get; set; } = string.Empty;
    public object Entity { get; set; } = null!;
}
