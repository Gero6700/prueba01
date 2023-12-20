namespace Senator.As400.Cloud.Sync.Api.Services; 

public static class ErrorHandlingService {
    public static IServiceCollection AddErrorHandling(this IServiceCollection services) {
        services.AddExceptionHandler<DefaultExceptionHandler>();
        services.AddExceptionHandler<BadRequestExceptionHandler>();
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<TimeOutExceptionHandler>();
        services.AddProblemDetails();
        return services;
    }
}