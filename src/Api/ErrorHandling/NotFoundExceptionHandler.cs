namespace Senator.As400.Cloud.Sync.Api.ErrorHandling; 

internal sealed class NotFoundExceptionHandler : IExceptionHandler {
    private readonly ILogger<NotFoundExceptionHandler> logger;
    
    public NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) {
        this.logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
        if (exception is not NotFoundException notFoundException) {
            return false;
        }

        logger.LogError(notFoundException, "Exception occurred: {Message}", notFoundException.Message);

        // Use RFC 7807: Problem Details for HTTP APIs.
        var problemDetails = new ProblemDetails {
            Status = StatusCodes.Status404NotFound,
            Type = exception.GetType().Name,
            Title = "Not Found",
            Detail = notFoundException.Message,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);
        
        return true;
    }
}