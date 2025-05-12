namespace Senator.As400.Cloud.Sync.Api.Services;
public static class RepositoriesService {
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) {
        services.AddScoped<IDbContext, DbContext>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISqlQueryBuilder, DapperQueryBuilder>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IRegimenRepository, RegimenRepository>();
        services.AddScoped<IServicioCategoriaRepository, ServicioCategoriaRepository>();
        services.AddScoped<IServicioRepository, ServicioRepository>();
        return services;
    }
}
