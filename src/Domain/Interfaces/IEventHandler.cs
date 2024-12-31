namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface IEventHandler<TEvent> {
    Task HandleAsync(TEvent @event);
}

