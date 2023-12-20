namespace Senator.As400.Cloud.Sync.Infrastructure.Messaging; 

public class RabbitMqMessagingSystem : IMessagingSystem {
    private readonly IConnection connection;
    private readonly IModel channel;
    
    public RabbitMqMessagingSystem(string username, string password, string vhost, string hostname) {
        Validate(username, password, vhost, hostname);
        var factory = new ConnectionFactory {
            UserName = username,
            Password = password,
            VirtualHost = vhost,
            HostName = hostname
        };
        connection = factory.CreateConnection();
        channel = connection.CreateModel();
    }

    public Task Subscribe<T>(string queueName, Func<T, Task> handler) {
        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) => {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var deserializedMessage = JsonSerializer.Deserialize<T>(message);
            await handler(deserializedMessage!);
        };
        channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        return Task.CompletedTask;
    }

    public Task Publish<T>(string queueName, T message) {
        var serializedMessage = string.Empty;
        try {
            serializedMessage = JsonSerializer.Serialize(message);
            var messageBodyBytes = Encoding.UTF8.GetBytes(serializedMessage);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: messageBodyBytes);
            return Task.CompletedTask;
        }
        catch {
            throw new MessageNotPublishedException(serializedMessage);
        }
    }

    public void Disconnect() {
        channel.Close();
        connection.Close();
    }
    
    private static void Validate(string username, string password, string vhost, string hostname) {
        Guard.IsNotNullOrEmpty(username);
        Guard.IsNotNullOrEmpty(password);
        Guard.IsNotNullOrEmpty(vhost);
        Guard.IsNotNullOrEmpty(hostname);
    }
}