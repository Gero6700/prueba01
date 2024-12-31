namespace Senator.As400.Cloud.Sync.Api.Services;
public class AvailSubscriptionPullService(
        IConfiguration configuration, 
        ILogger<AvailSubscriptionPullService> logger,
        ICreateClient createClient,
        ICreateContract createContract,
        IUpdateContract updateContract,
        IDeleteContract deleteContract,
        ICreateHotel createHotel,
        IUpdateHotel updateHotel
    ) {
    private SubscriberClient subscriberClient = null!;


    private async void AvailSubscriptionPullService(object? state) {
        var projectId = configuration["AvailGooglePubSub:ProjectId"];
        var subscriptionId = configuration["AvailGooglePubSub:SubscriptionId"];
        var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        subscriberClient ??= await SubscriberClient.CreateAsync(subscriptionName);

        await subscriberClient.StartAsync(async (PubsubMessage message, CancellationToken cancel) =>
        {
            //Se recupera y deserializa el mensaje
            var messageData = message.Data.ToStringUtf8();
            
            try {                
                var notification = JsonSerializer.Deserialize<As400Notification>(messageData, options);
                if (notification != null) {
                    switch (notification.Table) {
                        case nameof(TableType.Client):
                            var client = JsonSerializer.Deserialize<Usureg>(notification.Data);
                            if (client != null) {
                                if (notification.Operation == OperationType.Create.ToString()) {
                                    await createClient.Execute(client);
                                }
                                else if (notification.Operation == OperationType.Update.ToString()) {
                                    //await updateClient.Execute(client);
                                }
                            }
                            break;
                        case nameof(TableType.Contract):
                            var concabec = JsonSerializer.Deserialize<Concabec>(notification.Data);
                            if (concabec != null) {
                                if (notification.Operation == OperationType.Create.ToString()) {
                                    await createContract.Execute(concabec);                                
                                } else if (notification.Operation == OperationType.Update.ToString()) {                                
                                    await updateContract.Execute(concabec);
                                }
                                else if (notification.Operation == OperationType.Delete.ToString()) {
                                    await deleteContract.Execute(concabec.ContractCode);
                                }
                            }
                            break;
                        case nameof(TableType.Hotel):
                            var hotel = JsonSerializer.Deserialize<Reshotel>(notification.Data);
                            if (hotel != null) {
                                if (notification.Operation == OperationType.Create.ToString()) {
                                    await createHotel.Execute(hotel);
                                }
                                else if (notification.Operation == OperationType.Update.ToString()) {
                                    await updateHotel.Execute(hotel);
                                }
                            }
                            break;
                        default:
                            logger.LogWarning("Table {Table} is not supported", notification.Table);
                            break;
                    }
                }
            }
            catch (JsonException ex) {
                logger.LogError(ex, "An exception occurred while deserializing the message: {Message}", ex.Message);
            }
            catch (Exception ex) {
                logger.LogError(ex, "An exception occurred while processing the message: {Message}", ex.Message);
            }
            // Acknowledge the message
            return await Task.FromResult(SubscriberClient.Reply.Ack);
        });
    }

    private class As400Notification {
        public string Operation { get; set; } = string.Empty;
        public string Table { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
    }

    private enum OperationType {
        Create,
        Update,
        Delete
    }

    private enum TableType {
        Client,
        Contract,
        Hotel,
        Regime
    }
}
