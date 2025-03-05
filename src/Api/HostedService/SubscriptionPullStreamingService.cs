using System.Diagnostics;

namespace Senator.As400.Cloud.Sync.Api.HostedService;

//Servicio de extracción de mensajes mediante API de pull streaming de Google Pub/Sub.
//Para mas detalles de la API de StreamingPull de Google Pub/Sub: https://cloud.google.com/pubsub/docs/pull?hl=es-419#streamingpull_api
//Para mas detalles de las bibliotecas cliente de alto nivel para Pub/Sub: https://cloud.google.com/pubsub/docs/pull?hl=es-419#high_client_library

//El funcionamiento de este servicio es el siguiente:
//1. El suscriptor inicia la escucha de los mensajes.
//2. Por cada mensaje recibido, se deserializa el mensaje y se envía a un manejador de sincronización.
//3. Si la respuesta del manejador no es satisfactoria, se registra un error en el log.
//4. Si el error es de red/comunicación hacia la api (400, 500), el mensaje se marca con error y así poder reintentar.
//5. En caso contrario, se confirma el mensaje para que no se vuelva a recibir.


public class SubscriptionPullStreamingService(
        SubscriberClient subscriberClient,
        ILogger<SubscriptionPullStreamingService> logger,
        ISynchronizerHandler<GenericSynchronizationEvent> synchronizerHandler
    ) : BackgroundService {
    private readonly JsonSerializerOptions serializeOptions = new() { PropertyNameCaseInsensitive = true };
    private readonly Dictionary<string, Type> typeMap = new() {
        {nameof(TableType.Inventory), typeof(Resplaht)}
    };

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        await subscriberClient.StartAsync(async (PubsubMessage message, CancellationToken messageToken) => {
            if (stoppingToken.IsCancellationRequested) {
                return SubscriberClient.Reply.Nack;
            }
            //logger.LogInformation("Message received");
            return await ProcessMessageAsync(message);
        });
    }

    private async Task<SubscriberClient.Reply> ProcessMessageAsync(PubsubMessage message) {
        // Se recupera y deserializa el mensaje
        var messageData = string.Empty;
        try {
            //var stopwatch = Stopwatch.StartNew();
            messageData = message.Data.ToStringUtf8();
            var notification = JsonSerializer.Deserialize<As400Notification>(messageData, serializeOptions) ??
                throw new InvalidOperationException("The message could not be deserialized");
            var genericSynchronizationEvent = new GenericSynchronizationEvent {
                Operation = notification.Operation,
                Table = notification.Table,
                Data = notification.Data,
                Entity = DeserializeEntity(notification)
            };

            var httpResponse = await synchronizerHandler.HandleAsync(genericSynchronizationEvent);
            if (!httpResponse.IsSuccessStatusCode) {
                var content = await httpResponse.Content.ReadAsStringAsync();
                var errorCode = (int)httpResponse.StatusCode;
                ProblemDetails? problemDetails = null;

                try {
                    problemDetails = !string.IsNullOrWhiteSpace(content) ? JsonSerializer.Deserialize<ProblemDetails>(content, serializeOptions) : null;
                }
                catch { }

                if ((problemDetails == null && errorCode == 404) || errorCode == 500) {
                    //Se reintenta el mensaje
                    logger.LogError("Error sending message to Sync Api. {Message}",
                        GenerateLogApi(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, errorCode, content));
                    return SubscriberClient.Reply.Nack;
                }

                logger.LogError("The message has been refused. Error sending message to Sync Api. {Message}",
                    GenerateLogApi(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, errorCode, content));
            }

            return SubscriberClient.Reply.Ack;
        }
        catch (HttpRequestException ex) {
            logger.LogError("Error sending message to Sync Api: {Message}",
                GenerateLogMessage(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, ex.Message));
            return SubscriberClient.Reply.Nack;
        }
        catch (TimeoutException ex) {
            logger.LogError("Error sending message to Sync Api: {Message}",
                GenerateLogMessage(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, ex.Message));
            return SubscriberClient.Reply.Nack;
        }
        catch (Exception ex) {
            logger.LogError("The message has been refused. Error processing the message: {Message}",
                GenerateLogMessage(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, ex.Message));
            return SubscriberClient.Reply.Ack;
        }
    }

    private static string GenerateLogMessage(string projectId, string subscriptionId, PubsubMessage receivedMessage, string messageData, string errorMessage) {
        return $"{errorMessage}{Environment.NewLine}Project:{projectId}{Environment.NewLine}Subscription: {subscriptionId}{Environment.NewLine}" +
            $"MessageId: {receivedMessage.MessageId}{Environment.NewLine}PublishTime: {receivedMessage.PublishTime.ToDateTime()}{Environment.NewLine}Data: {messageData}";
    }

    private static string GenerateLogApi(string projectId, string subscriptionId, PubsubMessage received, string messageData, int errorCode, string? problemDetails) {
        return GenerateLogMessage(projectId, subscriptionId, received, messageData, $"Api synchronizer error: {problemDetails ?? ""}");
    }


    public override async Task StopAsync(CancellationToken stoppingToken) =>
        await subscriberClient.StopAsync(stoppingToken);

    private object DeserializeEntity(As400Notification notification) {             
        if (typeMap.TryGetValue(notification.Table, out var type)) {
            var entity = JsonSerializer.Deserialize(notification.Data, type, serializeOptions);
            return entity ?? throw new InvalidOperationException($"Deserialization returned null for table type: {notification.Table}");
        }

        throw new InvalidOperationException($"Unsupported table type: {notification.Table}");
    }   

    private class As400Notification : SynchronizationEvent { }
}
