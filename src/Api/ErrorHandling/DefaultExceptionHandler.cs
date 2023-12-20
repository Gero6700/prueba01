namespace Senator.As400.Cloud.Sync.Api.ErrorHandling; 

internal sealed class DefaultExceptionHandler : IExceptionHandler {
    private readonly ILogger<DefaultExceptionHandler> logger;

    public DefaultExceptionHandler(ILogger<DefaultExceptionHandler> logger) {
        this.logger = logger;
    }
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
        logger.LogError(exception, "An unexpected error occurred");

        // Use RFC 7807: Problem Details for HTTP APIs.
        var problemDetails = new ProblemDetails {
            Status = StatusCodes.Status500InternalServerError,
            Type = exception.GetType().Name,
            Title = "An unexpected error occurred",
            Detail = exception.Message,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);
        
        return true;
    }
}