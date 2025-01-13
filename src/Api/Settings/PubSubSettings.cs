namespace Senator.As400.Cloud.Sync.Api.Settings;
public class PubSubSettings {
    public required string TopicName { get; set; }
    public required string SubscriptionName { get; set; }
    public required int IntervalInSeconds { get; set; }
}
