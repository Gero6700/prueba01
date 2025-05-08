var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
    .Build();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningService();
builder.Services.AddHealthChecksService();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
builder.Services.AddErrorHandling();
builder.Services.AddSqlServerDatabase(configuration);
builder.Services.AddRepositories(configuration);
builder.Services.AddHttpClients(configuration);
builder.Services.AddApplicationServices();
builder.Services.AddUseCases();
builder.Services.AddSingleton<ISynchronizerHandler<GenericSynchronizationEvent>, GenericEventHandler>();

//subscription to quota
//var projectId = configuration["QuotaGooglePubSub:ProjectId"];
//var subscriptionId = configuration["QuotaGooglePubSub:SubscriptionId"];
//var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
//builder.Services.AddSubscriberClient(subscriptionName);
//builder.Services.AddHostedService<SubscriptionPullStreamingService>();

//subscription to avail with streaming
//var projectId = configuration["AvailGooglePubSub:ProjectId"];
//var subscriptionId = configuration["AvailGooglePubSub:SubscriptionId"];
//var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
//builder.Services.AddSubscriberClient(subscriptionName);
//builder.Services.AddHostedService<SubscriptionPullStreamingService>();

builder.Services.AddSubscriberServiceApiClient();

////subscription to avail and static 
//builder.Services.AddHostedService<AvailSubscriptionPullService>();
builder.Services.AddHostedService<StaticSubscriptionPullService>();


var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        foreach (var description in app.DescribeApiVersions()) {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });
}
app.UseExceptionHandler(opt => { });
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseRouting();
app.MapControllers();
app.MapHealthChecks("/health.json", new HealthCheckOptions {
    Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.Run();
