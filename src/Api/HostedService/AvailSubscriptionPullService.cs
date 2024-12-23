
using Google.Cloud.PubSub.V1;
using Newtonsoft.Json.Bson;


namespace Senator.As400.Cloud.Sync.Api.HostedService;
public class AvailSubscriptionPullService(IConfiguration configuration, SubscriberClient subscriberClient) : IHostedService {
    private Timer topicAvailPullTimer =  null!;

    public Task StartAsync(CancellationToken cancellationToken) {
        CreateAvailSubscriptionPullTimer();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) {
        topicAvailPullTimer.Change(Timeout.Infinite, 0);
        topicAvailPullTimer.Dispose();
        return Task.CompletedTask;
    }

    private void CreateAvailSubscriptionPullTimer() {
        var pullInterval = configuration.GetSection("AvailGooglePubSub").Get<PubSubSettings>()!.IntervalInMinutes;
        topicAvailPullTimer = new Timer(HandleAvailSubscriptionPull, null, TimeSpan.Zero, TimeSpan.FromMinutes(pullInterval));
    }

    private async void HandleAvailSubscriptionPull(object? state) {
        var projectId = configuration["AvailGooglePubSub:ProjectId"];
        var subscriptionId = configuration["AvailGooglePubSub:SubscriptionId"];
        var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);

        subscriberClient ??= await SubscriberClient.CreateAsync(subscriptionName);

        await subscriberClient.StartAsync(async (PubsubMessage message, CancellationToken cancel) =>
        {
            // Procesar el mensaje
            Console.WriteLine($"Mensaje recibido: {message.Data.ToStringUtf8()}");

            // Acknowledge the message
            return await Task.FromResult(SubscriberClient.Reply.Ack);
        });
    }
}
