

using Senator.As400.Cloud.Sync.Application.UseCases.Availability.CancellationPolicyLine;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Extra;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelRoomConfiguration;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Inventory;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Market;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.MinimunStay;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OccupancyRate;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplement;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementConfigurationPax;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroup;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.OfferAndSupplementGroupOfferAndSupplement;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricing;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.PeriodPricingPax;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Regime;

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
builder.Services.AddSingleton<ICreateCancellationPolicyLine, CreateCancellationPolicyLine>();
builder.Services.AddSingleton<IUpdateCancellationPolicyLine, UpdateCancellationPolicyLine>();

builder.Services.AddSingleton<ICreateClientType, CreateClientType>();
builder.Services.AddSingleton<IUpdateClientType, UpdateClientType>();
builder.Services.AddSingleton<IDeleteClientType, DeleteClientType>();

builder.Services.AddSingleton<ICreateClient, CreateClient>();
builder.Services.AddSingleton<IUpdateClient, UpdateClient>();
builder.Services.AddSingleton<IDeleteClient, DeleteClient>();

builder.Services.AddSingleton<ICreateContract, CreateContract>();
builder.Services.AddSingleton<IUpdateContract, UpdateContract>();
builder.Services.AddSingleton<IDeleteContract, DeleteContract>();

builder.Services.AddSingleton<ICreateExtra, CreateExtra>();
builder.Services.AddSingleton<IUpdateExtra, UpdateExtra>();
builder.Services.AddSingleton<IDeleteExtra, DeleteExtra>();

builder.Services.AddSingleton<ICreateHotel, CreateHotel>();
builder.Services.AddSingleton<IUpdateHotel, UpdateHotel>();

builder.Services.AddSingleton<ICreateHotelRoomConfiguration, CreateHotelRoomConfiguration>();
builder.Services.AddSingleton<IUpdateHotelRoomConfiguration, UpdateHotelRoomConfiguration>();
builder.Services.AddSingleton<IDeleteHotelRoomConfiguration, DeleteHotelRoomConfiguration>();

builder.Services.AddSingleton<ICreateInventory, CreateInventory>();
builder.Services.AddSingleton<IUpdateInventory, UpdateInventory>();
builder.Services.AddSingleton<IDeleteInventory, DeleteInventory>();

builder.Services.AddSingleton<ICreateMarket, CreateMarket>();
builder.Services.AddSingleton<IUpdateMarket, UpdateMarket>();
builder.Services.AddSingleton<IDeleteMarket, DeleteMarket>();

builder.Services.AddSingleton<ICreateMinimumStay, CreateMinimumStay>();
builder.Services.AddSingleton<IUpdateMinimumStay, UpdateMinimumStay>();

builder.Services.AddSingleton<ICreateOccupancyRate, CreateOccupancyRate>();
builder.Services.AddSingleton<IUpdateOccupancyRate, UpdateOccupancyRate>();
builder.Services.AddSingleton<IDeleteOccupancyRate, DeleteOccupancyRate>();

builder.Services.AddSingleton<ICreateOfferAndSupplement, CreateOfferAndSupplement>();
builder.Services.AddSingleton<IUpdateOfferAndSupplement, UpdateOfferAndSupplement>();

builder.Services.AddSingleton<ICreateOfferAndSupplementConfigurationPax, CreateOfferAndSupplementConfigurationPax>();
builder.Services.AddSingleton<IUpdateOfferAndSupplementConfigurationPax, UpdateOfferAndSupplementConfigurationPax>();
builder.Services.AddSingleton<IDeleteOfferAndSupplementConfigurationPax, DeleteOfferAndSupplementConfigurationPax>();

builder.Services.AddSingleton<ICreateOfferAndSupplementGroup, CreateOfferAndSupplementGroup>();
builder.Services.AddSingleton<IUpdateOfferAndSupplementGroup, UpdateOfferAndSupplementGroup>();
builder.Services.AddSingleton<IDeleteOfferAndSupplementGroup, DeleteOfferAndSupplementGroup>();

builder.Services.AddSingleton<ICreateOfferAndSupplementGroupOfferAndSupplement, CreateOfferAndSupplementGroupOfferAndSupplement>();
builder.Services.AddSingleton<IDeleteOfferAndSupplementGroupOfferAndSupplement, DeleteOfferAndSupplementGroupOfferAndSupplement>();

builder.Services.AddSingleton<ICreatePeriodPricing, CreatePeriodPricing>();
builder.Services.AddSingleton<IUpdatePeriodPricing, UpdatePeriodPricing>();

builder.Services.AddSingleton<ICreatePeriodPricingPax, CreatePeriodPricingPax>();
builder.Services.AddSingleton<IUpdatePeriodPricingPax, UpdatePeriodPricingPax>();
builder.Services.AddSingleton<IDeletePeriodPricingPax, DeletePeriodPricingPax>();

builder.Services.AddSingleton<ICreateRegimen, CreateRegime>();
builder.Services.AddSingleton<IUpdateRegimen, UpdateRegime>();

//Cupo
var projectId = configuration["AvailGooglePubSub:ProjectId"];
var subscriptionId = configuration["AvailGooglePubSub:SubscriptionId"];
var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
builder.Services.AddSubscriberClient(subscriptionName);

builder.Services.AddSubscriberServiceApiClient();
builder.Services.AddSingleton<ISynchronizerHandler<GenericSynchronizationEvent>, GenericEventHandler>();
//builder.Services.AddHostedService<PubSubPullStreamingService>();
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
