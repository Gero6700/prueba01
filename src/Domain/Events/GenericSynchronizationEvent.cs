namespace Senator.As400.Cloud.Sync.Application.Events;
public class GenericSynchronizationEvent : SynchronizationEvent {
    public object Entity { get; set; } = null!;
}
