namespace Senator.As400.Cloud.Sync.Api.Exceptions; 

public class SettingsNotFoundException : Exception {
    public SettingsNotFoundException(string? message = null)
        : base(message ?? "Settings Not Found")
    { }
}