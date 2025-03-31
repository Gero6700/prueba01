namespace Senator.As400.Cloud.Sync.Api.Services;
public static class RespositoriesService {
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IDbContext, DbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<ISqlQueryBuilder, DapperQueryBuilder>();
        services.AddScoped<IStaticHotelRepository, StaticHotelRepository>();
        return services;
    }
}
