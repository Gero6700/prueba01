namespace Senator.As400.Cloud.Sync.Infrastructure.Messaging; 

public interface IMessagingSystem {
    Task Subscribe<T>(string queueName, Func<T, Task> handler);
    Task Publish<T>(string queueName, T message);
    void Disconnect();
}