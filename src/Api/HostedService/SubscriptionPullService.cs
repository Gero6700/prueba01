using System.Collections.Concurrent;
using System.Threading;
using Senator.As400.Cloud.Sync.Infrastructure.Http.Exceptions;

namespace Senator.As400.Cloud.Sync.Api.HostedService;

//Servicio de extracción de mensajes mediante API de pull de Google Pub/Sub.
//Para mas detalles de la API de pull de Google Pub/Sub: https://cloud.google.com/pubsub/docs/pull?hl=es-419#pull_api
//Para mas detalles de las bibliotecas cliente de alto nivel para Pub/Sub: https://cloud.google.com/pubsub/docs/pull?hl=es-419#high_client_library

//El funcionamiento de este servicio es el siguiente:
//1. Realiza una operación de extracción (pull) asincrónica.
//2. Por cada mensaje recibido, se deserializa el mensaje y se envía a un manejador de sincronización.
//3. Si la respuesta del manejador no es satisfactoria, se registra un error en el log.
//4. Se confirma el mensaje para que no se vuelva a recibir.
//5. Se espera un breve período antes de la siguiente extracción.
//6. Si se produce un error en la extracción, se registra un error en el log.
//7. Se espera un breve período antes de la siguiente extracción.
//8. Se repiten los pasos 1 a 7 hasta que se cancele el servicio.

//A tener en cuenta:
//El deadline es el tiempo máximo que se espera para confirmar un mensaje. Si no se confirma antes de que expire, el mensaje se vuelve a enviar.
//Configurar el deadline en base al número de mensajes que se reciben y el tiempo que se tarda en procesarlos. Ahora está a 100 sg (20 mensajes x 5 sg).
//Si el deadline ha expirado, la confirmación del mensaje no fallará pero en realidad no se confirma y seguirá pendiente en la próxima lectura.
//Si se produce un error de red/comunicación hacia la api, ya sea por una HttpRequestException o porque devuelva un 404 o 500, se sale del bucle para asegurar el orden en el procesamiento. Se reintará la extracción en el siguiente ciclo.
//En cada mensaje de error se registra el AckId, PublishTime y Data del mensaje.
//Además, si el error ha venido por la api de sincronización, se registra el objeto devuelto en la respuesta.

//Tipos de error de la api de sincronización:
//400 error de entrada de datos o q ya exista en BBDD
//404 no encuentra algo en BBDD
//422 error en BBDD al intentar crear/modificar/eliminar la entidad
//500 error critico por excepcion no controlada
public abstract class SubscriptionPullService : BackgroundService {
    private readonly JsonSerializerOptions serializeOptions = new() { PropertyNameCaseInsensitive = true };
    protected readonly SubscriberServiceApiClient subscriberClient;
    protected readonly Microsoft.Extensions.Logging.ILogger logger;
    protected readonly ISynchronizerHandler<GenericSynchronizationEvent> synchronizationHandler;
    protected readonly IAs400NotificationApiClient? as400NotificationApiClient;

    protected SubscriptionPullService(
        SubscriberServiceApiClient subscriberClient,
        Microsoft.Extensions.Logging.ILogger logger,
        ISynchronizerHandler<GenericSynchronizationEvent> synchronizationHandler,
        IAs400NotificationApiClient? as400NotificationApiClient) {
        this.subscriberClient = subscriberClient;
        this.logger = logger;
        this.synchronizationHandler = synchronizationHandler;
        this.as400NotificationApiClient = as400NotificationApiClient;
    }

    protected abstract Dictionary<string, Type> typeMap { get; }
    protected abstract string GetProjectId();
    protected abstract string GetSubscriptionId();
    protected abstract int GetPullIntervalInSeconds();

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var projectId = GetProjectId();
        var subscriptionId = GetSubscriptionId();
        var intervalInSeconds = GetPullIntervalInSeconds();
        var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);

        var queue = new PriorityQueue<ReceivedMessage, DateTime>();
        var queueLock = new object();
        var semaphore = new SemaphoreSlim(5);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var response = await subscriberClient.PullAsync(subscriptionName, 50, stoppingToken);

                await Parallel.ForEachAsync(response.ReceivedMessages, stoppingToken, (receivedMessage, token) => {
                    lock (queueLock) {
                        queue.Enqueue(receivedMessage, receivedMessage.Message.PublishTime.ToDateTime());
                    }
                    return ValueTask.CompletedTask;
                });

                var tasks = new List<Task>();
                while (queue.TryDequeue(out var receivedMessage, out _))
                {
                    await semaphore.WaitAsync(stoppingToken);
                    tasks.Add(Task.Run(async () => {
                        try {
                            var messageData = receivedMessage.Message.Data.ToStringUtf8();
                            var notification = JsonSerializer.Deserialize<As400Notification>(messageData, options) ??
                                               throw new InvalidOperationException("Invalid message format");

                            var genericSynchronizationEvent = new GenericSynchronizationEvent
                            {
                                Operation = notification.Operation,
                                Table = notification.Table,
                                Data = notification.Data,
                                Entity = DeserializeEntity(notification)
                            };

                            var httpresponse = await synchronizationHandler.HandleAsync(genericSynchronizationEvent);
                            var statusAs400 = "Ok";
                            var textAs400 = string.Empty;

                            if (!httpresponse.IsSuccessStatusCode) {
                                var content = await httpresponse.Content.ReadAsStringAsync();
                                var errorCode = (int)httpresponse.StatusCode;
                                ProblemDetails? problemDetails = null;

                                try {
                                    problemDetails = !string.IsNullOrWhiteSpace(content) ? JsonSerializer.Deserialize<ProblemDetails>(content, options) : null;
                                }
                                catch (Exception) { //Para cuando content sea un error html
                                   problemDetails = null;
                                }

                                //Si el error no es de la api sale del bucle para asegurar el orden en el procesamiento. Se reintará la extracción en el siguiente ciclo.
                                if (problemDetails == null) {
                                    logger.LogError("Error sending message to Sync Api: {message}",
                                        GenerateLogApi(projectId, subscriptionId, receivedMessage.Message, errorCode, content));
                                    lock (queueLock) {
                                        queue.Clear();
                                    }
                                    return;
                                }
                                statusAs400 = errorCode.ToString();
                                textAs400 = problemDetails.Detail ?? content;
                                logger.LogError("The message has been refused. Error sending message to Sync Api: {message}",
                                    GenerateLogApi(projectId, subscriptionId, receivedMessage.Message, errorCode, content));
                            }

                            await subscriberClient.AcknowledgeAsync(subscriptionName, [receivedMessage.AckId]);
                            await SendAs400Notification(notification, statusAs400, textAs400?? string.Empty);

                        }
                        catch (Exception ex) when (
                            ex is HttpRequestException ||
                            ex is TimeoutException ||
                            ex is HttpException ||
                            ex.Message.Contains("HttpClient.Timeout")) {
                            lock (queueLock) { //se sale del bucle para asegurar el orden en el procesamiento.
                                queue.Clear();
                            }
                            return;
                        }
                        catch (Exception ex) {
                            logger.LogError("The message has been refused. Error processing the message {message}",
                               GenerateLogMessage(projectId, subscriptionId, receivedMessage.Message, ex.Message));
                            await subscriberClient.AcknowledgeAsync(subscriptionName, [receivedMessage.AckId]);
                        }
                        finally {
                            semaphore.Release();
                        }
                    }, stoppingToken));
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error pulling messages: {Message}", ex.Message);
            }
        }

    }

    private static string GenerateLogMessage(string projectId, string subscriptionId, PubsubMessage receivedMessage, string errorMessage) {
        return $"{errorMessage}{Environment.NewLine}" +
            $"Project:{projectId}{Environment.NewLine}" +
            $"Subscription: {subscriptionId}{Environment.NewLine}" +
            $"MessageId: {receivedMessage.MessageId}{Environment.NewLine}" +
            $"PublishTime: {receivedMessage.PublishTime.ToDateTime()}{Environment.NewLine}" +
            $"Data: {receivedMessage.Data.ToStringUtf8()}";
    }

    private static string GenerateLogApi(string projectId, string subscriptionId, PubsubMessage received, int errorCode, string? problemDetails) {
        return GenerateLogMessage(projectId, subscriptionId, received, $"Api synchronizer error: {problemDetails ?? ""}");
    }

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

    private (string,string) GetIdFechamodi(As400Notification notification) {
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
