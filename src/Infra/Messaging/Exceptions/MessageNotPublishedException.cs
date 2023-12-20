namespace Senator.As400.Cloud.Sync.Infrastructure.Messaging.Exceptions; 

public sealed class MessageNotPublishedException : Exception {
    private readonly string messageToPublish;

    public MessageNotPublishedException(string messageToPublish) {
        this.messageToPublish = messageToPublish;
        Data[nameof(messageToPublish)] = messageToPublish;
    }
}