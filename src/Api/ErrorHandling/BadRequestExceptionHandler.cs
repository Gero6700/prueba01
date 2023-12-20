namespace Senator.As400.Cloud.Sync.Api.ErrorHandling; 

internal sealed class BadRequestExceptionHandler : IExceptionHandler {
    private readonly ILogger<BadRequestExceptionHandler> logger;

    public BadRequestExceptionHandler(ILogger<BadRequestExceptionHandler> logger) {
        this.logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
        if (exception is not BadRequestException badRequestException) {
            return false;
        }

        logger.LogError(badRequestException, "Exception occurred: {Message}", badRequestException.Message);

        // Use RFC 7807: Problem Details for HTTP APIs.
        var problemDetails = new ProblemDetails {
            Status = StatusCodes.Status400BadRequest,
            Type = exception.GetType().Name,
            Title = "Bad Request",
            Detail = badRequestException.Message,
            Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}"
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);
        
        return true;
    }
}