namespace Senator.As400.Cloud.Sync.Api.Logging;
public class AlwaysLevelCompactJsonFormatter : ITextFormatter {
    public void Format(LogEvent logEvent, TextWriter output) {
        if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));
        if (output == null) throw new ArgumentNullException(nameof(output));

        output.Write('{');

        // Timestamp
        output.Write("\"@t\":\"");
        output.Write(logEvent.Timestamp.UtcDateTime.ToString("O"));
        output.Write('\"');

        // MessageTemplate
        output.Write(",\"@mt\":");
        JsonValueFormatter.WriteQuotedJsonString(logEvent.MessageTemplate.Text, output);

        // Rendered message
        if (logEvent.MessageTemplate.Text != logEvent.RenderMessage()) {
            output.Write(",\"@m\":");
            JsonValueFormatter.WriteQuotedJsonString(logEvent.RenderMessage(), output);
        }

        // Level (siempre presente)
        output.Write(",\"@l\":\"");
        output.Write(logEvent.Level.ToString());
        output.Write('\"');

        // Exception
        if (logEvent.Exception != null) {
            output.Write(",\"@x\":");
            JsonValueFormatter.WriteQuotedJsonString(logEvent.Exception.ToString(), output);
        }

        // Properties
        foreach (var property in logEvent.Properties) {
            output.Write(',');
            JsonValueFormatter.WriteQuotedJsonString(property.Key, output);
            output.Write(':');
            new JsonValueFormatter().Format(property.Value, output);
        }

        output.Write('}');
        output.WriteLine();
    }
}
