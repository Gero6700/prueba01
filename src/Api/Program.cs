

using Senator.As400.Cloud.Sync.Application.UseCases.Availability.CancellationPolicyLine;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.ClientType;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Extra;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelRoomConfiguration;
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.HotelSeason;
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
using Senator.As400.Cloud.Sync.Application.UseCases.Availability.Room;
using Senator.As400.Cloud.Sync.Application.UseCases.Static;

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

builder.Services.AddHttpClients(configuration);
builder.Services.AddSingleton<ICreateCancellationPolicy, CreateCancellationPolicy>();
builder.Services.AddSingleton<IUpdateCancellationPolicy, UpdateCancellationPolicy>();

builder.Services.AddSingleton<ICreateIntegrationClientType, CreateIntegrationClientType>();
builder.Services.AddSingleton<IUpdateIntegrationClientType, UpdateIntegrationClientType>();
builder.Services.AddSingleton<IDeleteIntegrationClientType, DeleteIntegrationClientType>();

builder.Services.AddSingleton<ICreateIntegration, CreateIntegration>();
builder.Services.AddSingleton<IUpdateIntegration, UpdateIntegration>();
builder.Services.AddSingleton<IDeleteIntegration, DeleteIntegration>();

builder.Services.AddSingleton<ICreateContractHeader, CreateContractHeader>();
builder.Services.AddSingleton<IUpdateContractHeader, UpdateContractHeader>();

builder.Services.AddSingleton<ICreateExtra, CreateExtra>();
builder.Services.AddSingleton<IUpdateExtra, UpdateExtra>();
builder.Services.AddSingleton<IDeleteExtra, DeleteExtra>();

builder.Services.AddSingleton<ICreateHotel, CreateHotel>();
builder.Services.AddSingleton<IUpdateHotel, UpdateHotel>();

builder.Services.AddSingleton<IPushHotelRoomConfiguration, PushHotelRoomConfiguration>();
builder.Services.AddSingleton<IPushHotelSeason, PushHotelSeason>();

builder.Services.AddSingleton<ICreateInventory, CreateInventory>();
builder.Services.AddSingleton<IUpdateInventory, UpdateInventory>();

builder.Services.AddSingleton<ICreateMarket, CreateMarket>();

builder.Services.AddSingleton<ICreateMinimumStay, CreateMinimumStay>();
builder.Services.AddSingleton<IUpdateMinimumStay, UpdateMinimumStay>();
builder.Services.AddSingleton<IDeleteMinimumStay, DeleteMinimumStay>();

builder.Services.AddSingleton<ICreateOccupancyRate, CreateOccupancyRate>();
builder.Services.AddSingleton<IUpdateOccupancyRate, UpdateOccupancyRate>();

builder.Services.AddSingleton<ICreateOfferSupplement, CreateOfferSupplement>();
builder.Services.AddSingleton<IUpdateOfferSupplement, UpdateOfferSupplement>();

builder.Services.AddSingleton<ICreateOfferSupplementConfigurationPax, CreateOfferSupplementConfigurationPax>();
builder.Services.AddSingleton<IUpdateOfferSupplementConfigurationPax, UpdateOfferSupplementConfigurationPax>();
builder.Services.AddSingleton<IDeleteOfferSupplementConfigurationPax, DeleteOfferSupplementConfigurationPax>();

builder.Services.AddSingleton<ICreateOfferSupplementGroup, CreateOfferSupplementGroup>();
builder.Services.AddSingleton<IUpdateOfferSupplementGroup, UpdateOfferSupplementGroup>();

builder.Services.AddSingleton<ICreateOfferSupplementGroupRelation, CreateOfferSupplementGroupRelation>();
builder.Services.AddSingleton<IDeleteOfferSupplementGroupRelation, DeleteOfferSupplementGroupRelation>();

builder.Services.AddSingleton<ICreatePeriodPricing, CreatePeriodPricing>();
builder.Services.AddSingleton<IUpdatePeriodPricing, UpdatePeriodPricing>();

builder.Services.AddSingleton<ICreatePeriodPricingPax, CreatePeriodPricingPax>();
builder.Services.AddSingleton<IUpdatePeriodPricingPax, UpdatePeriodPricingPax>();
builder.Services.AddSingleton<IDeletePeriodPricingPax, DeletePeriodPricingPax>();

builder.Services.AddSingleton<ICreateMeal, CreateMeal>();

builder.Services.AddSingleton<ICreateRoom, CreateRoom>();

builder.Services.AddSingleton<ICreateStaticExtraTranslation, CreateStaticExtraTranslation>();
builder.Services.AddSingleton<IUpdateStaticExtraTranslation, UpdateStaticExtraTranslation>();
builder.Services.AddSingleton<IDeleteStaticExtraTranslation, DeleteStaticExtraTranslation>();

builder.Services.AddSingleton<ICreateStaticOfferSupplementTranslation, CreateStaticOfferSuplementTranslation>();
builder.Services.AddSingleton<IUpdateStaticOfferSupplementTranslation, UpdateStaticOfferSupplementTranslation>();
builder.Services.AddSingleton<IDeleteStaticOfferSupplementTranslation, DeleteStaticOfferSupplementTranslation>();

builder.Services.AddSingleton<ICreateStaticPaymentType, CreateStaticPaymentType>();
builder.Services.AddSingleton<IUpdateStaticPaymentType, UpdateStaticPaymentType>();
builder.Services.AddSingleton<IDeleteStaticPaymentType, DeleteStaticPaymentType>();

builder.Services.AddSingleton<ICreateStaticTax, CreateStaticTax>();
builder.Services.AddSingleton<IUpdateStaticTax, UpdateStaticTax>();
builder.Services.AddSingleton<IDeleteStaticTax, DeleteStaticTax>();

builder.Services.AddSingleton<ISynchronizerHandler<GenericSynchronizationEvent>, GenericEventHandler>();

//subscription to quota
var projectId = configuration["QuotaGooglePubSub:ProjectId"];
var subscriptionId = configuration["QuotaGooglePubSub:SubscriptionId"];
var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
builder.Services.AddSubscriberClient(subscriptionName);
builder.Services.AddHostedService<SubscriptionPullStreamingService>();

//subscription to avail with streaming
//var projectId = configuration["AvailGooglePubSub:ProjectId"];
//var subscriptionId = configuration["AvailGooglePubSub:SubscriptionId"];
//var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);
//builder.Services.AddSubscriberClient(subscriptionName);
//builder.Services.AddHostedService<SubscriptionPullStreamingService>();

builder.Services.AddSubscriberServiceApiClient();

//subscription to avail and static 
builder.Services.AddHostedService<AvailSubscriptionPullService>();
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
