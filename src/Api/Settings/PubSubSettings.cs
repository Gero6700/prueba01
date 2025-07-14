namespace Senator.As400.Cloud.Sync.Api.Settings;
public class PubSubSettings {
    public required string ProjectId { get; set; }
    public required string SubscriptionId { get; set; }
    public required int PullMaxMessages { get; set; }
}
