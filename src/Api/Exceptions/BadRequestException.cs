namespace Senator.As400.Cloud.Sync.Api.Exceptions;

public class BadRequestException : Exception {
    public BadRequestException(string? message = null)
        : base(message ?? "Bad Request")
    { }
}
