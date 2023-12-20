namespace Senator.As400.Cloud.Sync.Api.ErrorHandling; 

internal sealed class TimeOutExceptionHandler : IExceptionHandler {
    private readonly ILogger<TimeOutExceptionHandler> logger;
    
    public TimeOutExceptionHandler(ILogger<TimeOutExceptionHandler> logger) {
        this.logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
        if (exception is not TimeoutException timeoutException) {
            return false;
        }

        logger.LogError(timeoutException, "Exception occurred: {Message}", timeoutException.Message);

        // Use RFC 7807: Problem Details for HTTP APIs.
        var problemDetails = new ProblemDetails {
            Status = StatusCodes.Status408RequestTimeout,
            Type = exception.GetType().Name,
            Title = "A timeout occurred",
            Detail = timeoutException.Message,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);
        
        return true;
    }
}