using System.Diagnostics;
using Senator.As400.Cloud.Sync.Infrastructure.Providers;

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
        ISynchronizerHandler<GenericSynchronizationEvent> synchronizerHandler,
        IAs400NotificationApiClient? as400NotificationApiClient
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
            return await ProcessMessageAsync(message);
        });
    }

    private async Task<SubscriberClient.Reply> ProcessMessageAsync(PubsubMessage message) {
        // Se recupera y deserializa el mensaje
        var messageData = string.Empty;
        try {
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
            var statusAs400 = "Ok";
            var textAs400 = string.Empty;
            if (!httpResponse.IsSuccessStatusCode) {
                var content = await httpResponse.Content.ReadAsStringAsync();
                var errorCode = (int)httpResponse.StatusCode;
                ProblemDetails? problemDetails = null;

                try {
                    problemDetails = !string.IsNullOrWhiteSpace(content) ? JsonSerializer.Deserialize<ProblemDetails>(content, serializeOptions) : null;
                }
                catch { }

                if (problemDetails == null) {
                    //Se reintenta el mensaje
                    logger.LogError("Error sending message to Sync Api. {Message}",
                        GenerateLogApi(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, errorCode, content));
                    return SubscriberClient.Reply.Nack;
                }
                statusAs400 = errorCode.ToString();
                textAs400 = problemDetails.Detail ?? content;
                logger.LogError("The message has been refused. Error sending message to Sync Api. {Message}",
                    GenerateLogApi(subscriberClient.SubscriptionName.ProjectId, subscriberClient.SubscriptionName.SubscriptionId, message, messageData, errorCode, content));
            }

            await SendAs400Notification(notification, statusAs400, textAs400?? string.Empty);
            return SubscriberClient.Reply.Ack;
        }
        catch (Exception ex) when (
            ex is HttpRequestException ||
            ex is TimeoutException ||
            ex.Message.Contains("HttpClient.Timeout")) {
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

    private async Task SendAs400Notification(As400Notification notification, string statusAs400, string textAs400) {
        try {
            if (as400NotificationApiClient is not null) {
                var (id, fechaModi) = GetIdFechamodi(notification);
                if (textAs400.Length > 250)
                    textAs400 = textAs400[..250];
                var response = await as400NotificationApiClient.SendNotification(notification.Table, id, fechaModi, statusAs400, textAs400);
                if (!response.IsSuccessStatusCode) {
                    logger.LogError("Error sending notification to AS400 API: {message}", response.StatusCode);
                }
            }
        }
        catch { }
    }

    private (string, string) GetIdFechamodi(As400Notification notification) {
        var data = JsonSerializer.Deserialize<Dictionary<string, object>>(notification.Data, serializeOptions);
        if (data != null && data.TryGetValue("Id", out var idObj) && data.TryGetValue("Fechamodi", out var fechaModiObj)) {
            var id = idObj?.ToString();
            var fechaModi = fechaModiObj?.ToString();
            return (id ?? string.Empty, fechaModi ?? string.Empty);
        }
        return (string.Empty, string.Empty);
    }

    private class As400Notification : SynchronizationEvent { }
}
