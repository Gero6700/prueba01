using Senator.As400.Cloud.Sync.Application.Services.Static;

namespace Senator.As400.Cloud.Sync.Api.Services;
public static class ApplicationService {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddScoped<IHotelService, HotelService>();
        return services;
    }
}
