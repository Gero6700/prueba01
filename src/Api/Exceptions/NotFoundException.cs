namespace Senator.As400.Cloud.Sync.Api.Exceptions; 

public class NotFoundException : Exception {
    public NotFoundException(string? message = null)
        : base(message ?? "Not Found")
    { }
}