namespace Senator.As400.Cloud.Sync.Application.Events;
public class GenericNotificationEvent : NotificationEvent {
    public object Entity { get; set; } = null!;
}
