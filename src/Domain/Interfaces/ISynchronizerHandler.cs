namespace Senator.As400.Cloud.Sync.Application.Interfaces;
public interface ISynchronizerHandler<TEvent> {
    Task<HttpResponseMessage> HandleAsync(TEvent @event);
}

