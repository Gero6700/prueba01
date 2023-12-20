namespace Senator.As400.Cloud.Sync.Tests.Common.Extensions;

public static class DateTimeExtensions {
    public static DateTime WithoutMilliseconds(this DateTime dateTime) {
        return dateTime.AddTicks(-(dateTime.Ticks % TimeSpan.TicksPerSecond));
    }
}