

using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Client;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Hotel;

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

//TODO: Pendiente de ver con Jesus
builder.Services.AddHttpClients(configuration);
builder.Services.AddSingleton<ICreateClient, CreateClient>();
builder.Services.AddSingleton<ICreateContract, CreateContract>();
builder.Services.AddSingleton<IUpdateContract, UpdateContract>();
builder.Services.AddSingleton<IDeleteContract, DeleteContract>();
builder.Services.AddSingleton<ICreateHotel, CreateHotel>();
builder.Services.AddSingleton<IUpdateHotel, UpdateHotel>();
//builder.Services.AddSingleton<SubscriberServiceApiClient>(SubscriberServiceApiClient.Create());
//builder.Services.AddSingleton<SubscriberClient>(); 
builder.Services.AddHostedService<AvailSubscriptionPullService>();


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
