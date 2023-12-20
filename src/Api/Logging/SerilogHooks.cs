namespace Senator.As400.Cloud.Sync.Api.Logging;

public class SerilogHooks {
    public static HeaderWriter CustomHeaderWriter =>
        new HeaderWriter(Environment.NewLine + new string('-', 50) + $" New execution at {DateTime.UtcNow}", true);
}