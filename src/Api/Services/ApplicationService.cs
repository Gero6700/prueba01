using Senator.As400.Cloud.Sync.Application.Services.Static;

namespace Senator.As400.Cloud.Sync.Api.Services;
public static class ApplicationService {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IServicioCategoriaService, ServicioCategoriaService>();
        services.AddScoped<IServicioService, ServicioService>();
        services.AddScoped<IRegimenService, RegimenService>();
        services.AddScoped<IPushHotelServiceHandler, PushHotelServiceHandler>();
        services.AddScoped<IPushServiceCategoryHandler, PushServiceCategoryHandler>();
        services.AddScoped<IPushServiceHandler, PushServiceHandler>();
        services.AddScoped<IPushMealServiceHandler, PushMealServiceHandler>();
        return services;
    }
}
