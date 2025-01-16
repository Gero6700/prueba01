namespace Senator.As400.Cloud.Sync.Api.HostedService;

//Servicio de extraccion de mensajes mediante API de pull de Google Pub/Sub.
//Para mas detalles de la API de Google Pub/Sub: https://cloud.google.com/pubsub/docs/pull?hl=es-419#high_client_library

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
//Además, si el error ha venido por la api de sincronización, se registra el objeto devuelto.
public abstract class BaseSubscriptionPullService : BackgroundService {
    private readonly JsonSerializerOptions serializeOptions = new() { PropertyNameCaseInsensitive = true };
    //private readonly Dictionary<string, Type> typeMap = new() {
    //    {nameof(TableType.CancellationPolicyLine), typeof(Congasan)},
    //    {nameof(TableType.Client), typeof(Usureg)},
    //    {nameof(TableType.ClientType), typeof(Restagen)},
    //    {nameof(TableType.Contract), typeof(Concabec)},
    //    {nameof(TableType.Extra), typeof(Conextra)},
    //    {nameof(TableType.Hotel), typeof(Reshotel)},
    //    {nameof(TableType.HotelRoomConfiguration), typeof(Resthaho)},
    //    {nameof(TableType.Inventory), typeof(Resplaht)},
    //    {nameof(TableType.Market), typeof(Merca)},
    //    {nameof(TableType.MinimumStay), typeof(Conestmi)},
    //    {nameof(TableType.OccupancyRate), typeof(Resthaco)},
    //    {nameof(TableType.OfferAndSupplement), typeof(Conofege)},
    //    {nameof(TableType.OfferAndSupplementConfigurationPax), typeof(Condtof)},
    //    {nameof(TableType.OfferAndSupplementGroup), typeof(ConofcomHeader)},
    //    {nameof(TableType.OfferAndSupplementGroupOfferAndSupplement), typeof(ConofcomLine)},
    //    {nameof(TableType.PeriodPricing), typeof(Conpreci)},
    //    {nameof(TableType.PeriodPricingPax), typeof(Condtos)},
    //    {nameof(TableType.Regimen), typeof(Restregi)}
    //};

    protected readonly SubscriberServiceApiClient subscriberClient;
    protected readonly Microsoft.Extensions.Logging.ILogger logger;
    protected readonly ISynchronizerHandler<GenericSynchronizationEvent> synchronizationHandler;

    protected BaseSubscriptionPullService(
        SubscriberServiceApiClient subscriberClient,
        Microsoft.Extensions.Logging.ILogger logger,
        ISynchronizerHandler<GenericSynchronizationEvent> synchronizationHandler
    ) {
        this.subscriberClient = subscriberClient;
        this.logger = logger;
        this.synchronizationHandler = synchronizationHandler;
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

        while (!stoppingToken.IsCancellationRequested) {
            try {
                var response = await subscriberClient.PullAsync(subscriptionName, 20, stoppingToken);

                foreach (var receivedMessage in response.ReceivedMessages) {
                    var messageData = string.Empty;
                    try {
                        messageData = receivedMessage.Message.Data.ToStringUtf8();
                        var notification = JsonSerializer.Deserialize<As400Notification>(messageData, options) ?? throw new InvalidOperationException("The message could not be deserialized");
                        var genericSynchronizationEvent = new GenericSynchronizationEvent {
                            Operation = notification.Operation,
                            Table = notification.Table,
                            Data = notification.Data,
                            Entity = DeserializeEntity(notification)
                        };
                        var httpresponse = await synchronizationHandler.HandleAsync(genericSynchronizationEvent);

                        if (!httpresponse.IsSuccessStatusCode) {
                            var content = await httpresponse.Content.ReadAsStringAsync();
                            var errorCode = (int)httpresponse.StatusCode;
                            ProblemDetails? problemDetails = null;

                            try {
                                problemDetails = !string.IsNullOrWhiteSpace(content) ? JsonSerializer.Deserialize<ProblemDetails>(content, options) : null;
                            }
                            catch { }

                            if (errorCode == 404 || errorCode == 500) {
                                logger.LogError("Pulling process is aborted, it will restart automatically. An error occurred while sending the message to Synchronizer Api: {message}",
                                    GenerateLogApi(projectId, subscriptionId, receivedMessage.Message, messageData, errorCode, problemDetails));
                                break;
                            }
                            else {
                                logger.LogError("The message has been refused. An error occurred while sending the message to Synchronizer Api: {message}",
                                    GenerateLogApi(projectId, subscriptionId, receivedMessage.Message, messageData, errorCode, problemDetails));
                            }
                        }
                    }
                    catch (JsonException ex) {
                        logger.LogError("The message has been refused. An exception occurred while deserializing the message: {message}",
                            GenerateLogMessage(projectId, subscriptionId, receivedMessage.Message, messageData, ex.Message));
                    }
                    catch (HttpRequestException ex) {
                        logger.LogError("Pulling process is aborted, it will restart automatically. An exception occurred while sending the message to Synchronizer Api: {message}",
                            GenerateLogMessage(projectId, subscriptionId, receivedMessage.Message, messageData, ex.Message));
                        break;
                    }
                    catch (Exception ex) {
                        logger.LogError("The message has been refused. An exception occurred while processing the message {message}",
                            GenerateLogMessage(projectId, subscriptionId, receivedMessage.Message, messageData, ex.Message));
                    }

                    await subscriberClient.AcknowledgeAsync(subscriptionName, new[] { receivedMessage.AckId });
                }
            }
            catch (Exception ex) {
                logger.LogError(ex, "An exception occurred while pulling messages: {Message}", ex.Message);
            }

            await Task.Delay(TimeSpan.FromSeconds(intervalInSeconds), stoppingToken);
        }
    }

    private static string GenerateLogMessage(string projectId, string subscriptionId, PubsubMessage receivedMessage, string messageData, string errorMessage) {
        return $"{errorMessage}{Environment.NewLine}Project:{projectId}{Environment.NewLine}Subscription: {subscriptionId}{Environment.NewLine}" +
            $"MessageId: {receivedMessage.MessageId}{Environment.NewLine}PublishTime: {receivedMessage.PublishTime.ToDateTime()}{Environment.NewLine}Data: {messageData}";
    }

    private static string GenerateLogApi(string projectId, string subscriptionId, PubsubMessage received, string messageData, int errorCode, ProblemDetails? problemDetails) {
        return GenerateLogMessage(projectId, subscriptionId, received, messageData,
            $"Api synchronizer error: {problemDetails?.Status ?? errorCode}{Environment.NewLine}Type: {problemDetails?.Type}{Environment.NewLine}" +
            $"Title: {problemDetails?.Title}{Environment.NewLine}Detail: {problemDetails?.Detail}{Environment.NewLine}Instance: {problemDetails?.Instance}");
    }

    private object DeserializeEntity(As400Notification notification) {
        if (typeMap.TryGetValue(notification.Table, out var type)) {
            var entity = JsonSerializer.Deserialize(notification.Data, type, serializeOptions);
            return entity ?? throw new InvalidOperationException($"Deserialization returned null for table type: {notification.Table}");
        }

        throw new InvalidOperationException($"Unsupported table type: {notification.Table}");
    }

    private class As400Notification : SynchronizationEvent { }
}
